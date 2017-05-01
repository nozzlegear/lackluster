using System;
using Microsoft.Extensions.CommandLineUtils;
using Lackluster.Infrastructure;
using Lackluster.Elements;
using System.Reflection;
using System.Linq;
using Lackluster.Attributes;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "Lackluster Utils";
            app.Description = "Utilities for building Lackluster.";
            app.HelpOption("-?|-h|--help");

            app.Command("elements", (config) =>
            {
                // Get all of the classes in the Lackluster.Elements namespace that implement the ComponentHelper attribute.
                var lackluster = DependencyContext.Default
                    .GetDefaultAssemblyNames()
                    .Where(name => name.Name == "Lackluster")
                    .First();
                var assembly = Assembly.Load(lackluster);
                var types = assembly
                    .GetTypes()
                    .Where(t => t.Namespace == "Lackluster.Elements")
                    .Select(t => new { type = t, attribute = t.GetTypeInfo().GetCustomAttribute(typeof(ComponentHelper)) as ComponentHelper })
                    .Where(t => t.attribute != null);

                if (types.Count() == 0)
                {
                    Console.WriteLine("Types list is empty, no type could be found in namespace Lackluster.Elements that used attribute ComponentHelper.");

                    return;
                }

                StringBuilder sb = new StringBuilder();
                string returnType = nameof(Element);
                string childType = nameof(BaseObject);
                string nl = Environment.NewLine;
                string tab = "\t";

                sb.AppendLine("using Lackluster.Infrastructure;");
                sb.AppendLine("using Lackluster.Elements;");
                sb.Append(nl + nl);
                sb.AppendLine("public class ComponentPartials");
                sb.Append("{");

                // Append compiled helpers
                foreach (var type in types)
                {
                    ComponentHelper attribute = type.attribute;
                    string name = attribute.TargetType.Name;
                    string signature = $"{tab}protected virtual {returnType} {name}";
                    string returnPrefix = $"{tab}return new {name}(null, null, null, ";
                    string returnSuffix = $");";
                    string openingBrace = tab + "{";
                    string closingBrace = tab + "}";

                    sb.Append(nl);
                    sb.AppendLine($"{signature}(params {childType}[] children)");
                    sb.AppendLine(openingBrace);
                    sb.AppendLine($"{tab}{returnPrefix}children{returnSuffix}");
                    sb.AppendLine(closingBrace);

                    if (! attribute.HasTextChild)
                    {
                        continue;
                    }

                    sb.Append(nl);
                    sb.AppendLine($"{signature}(string text)");
                    sb.AppendLine(openingBrace);
                    sb.AppendLine($"{tab}{returnPrefix}new Text(text){returnSuffix}");
                    sb.AppendLine(closingBrace);
                }

                sb.Append("}");


                string output = sb.ToString();

                System.IO.File.WriteAllText("./generated.cs", output);
                Console.WriteLine(output);
            });

            app.OnExecute(() =>
            {
                app.ShowHelp();

                return 0;
            });

            app.Execute(args);
        }
    }
}
