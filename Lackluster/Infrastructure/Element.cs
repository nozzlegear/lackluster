using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lackluster.Infrastructure
{
    public abstract class Element<T> : BaseObject where T: Element<T>
    {
        public abstract string TagName { get; }

        public virtual string ElementId { get; set; }

        private IEnumerable<string> _ElementClassNames { get; set; }

        public virtual IEnumerable<string> ElementClassNames
        {
            get
            {
                _ElementClassNames = _ElementClassNames.Guard();

                return _ElementClassNames;
            }
            set
            {
                _ElementClassNames = value;
            }
        }

        private Dictionary<string, string> _ElementAttributes { get; set; }

        public virtual Dictionary<string, string> ElementAttributes
        {
            get
            {
                _ElementAttributes = _ElementAttributes.Guard();

                return _ElementAttributes;
            }
            set
            {
                _ElementAttributes = value;
            }
        }

        private IEnumerable<BaseObject> _ElementChildren { get; set; }

        public virtual IEnumerable<BaseObject> ElementChildren 
        {  
            get 
            {
                _ElementChildren = _ElementChildren.Guard();

                return _ElementChildren;
            }
            set
            {
                _ElementChildren = value;
            }
        }

        protected Element(
            string id = null, 
            IEnumerable<string> classNames = null, 
            Dictionary<string, string> attributes = null, 
            params BaseObject[] children
        )
        {
            ElementId = id;
            ElementClassNames = classNames;
            ElementAttributes = attributes;
            ElementChildren = children;
        }

        /// <summary>
        /// Combines the attributes, id and classnames into an HTML string.
        /// </summary>
        public virtual string FormatAttributes()
        {
            var attributes = ElementAttributes
                .Guard()
                .ChainSet("id", ElementId)
                .ChainSet("class", string.Join(" ", ElementClassNames.Guard()))
                .Where(kvp => ! string.IsNullOrEmpty(kvp.Value))
                .Select(kvp => $"{EscapeString(kvp.Key)}=\"{EscapeString(kvp.Value)}\"");

            return string.Join(" ", attributes);
        }

        /// <summary>
        /// Formats the <see cref="TagName" /> with id, attributes and class names.
        /// </summary>
        public virtual string FormatTagNameWithAttributes(bool selfClosingTag)
        {
            string attributes = FormatAttributes();
            string closer = selfClosingTag ? "/" : "";
            string spacer = attributes.Count() == 0 ? "" : " ";
            
            return $"<{TagName}{spacer}{attributes}{closer}>";
        }

        public override async Task<string> RenderToStaticMarkup()
        {
            string tagStart = FormatTagNameWithAttributes(false);
            string tagEnd = $"</{TagName}>";

            StringBuilder sb = new StringBuilder();
            var children = ElementChildren.Guard();

            foreach (var child in children)
            {
                string markup = await child.RenderToStaticMarkup();

                sb.Append(markup);
            };

            return tagStart + sb.ToString() + tagEnd;
        }

        public T ClassNames(params string[] classNames)
        {
            ElementClassNames = classNames;

            return (T) this;
        }

        public T ClassName(string className)
        {
            var list = ElementClassNames.ToList();

            list.Add(className);

            ElementClassNames = list;

            return (T) this;
        }

        public T Id(string id)
        {
            ElementId = id;

            return (T) this;
        }

        public T Children(params BaseObject[] children)
        {
            ElementChildren = children;

            return (T) this;
        }

        public T Attributes(Dictionary<string, string> attributes)
        {
            ElementAttributes = attributes;

            return (T) this;
        }

        public T Attribute(string key, string value)
        {
            ElementAttributes.Set(key, value);

            return (T) this;
        }
    }
}