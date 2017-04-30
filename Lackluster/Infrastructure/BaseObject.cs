using System.Threading.Tasks;

namespace Lackluster.Infrastructure
{
    public abstract class BaseObject
    {
        /// <summary>
        /// Encodes a string for use in HTML by escaping HTML characters.
        /// </summary>
        public virtual string EscapeString(string value)
        {
            return System.Net.WebUtility.HtmlEncode(value);
        }

        /// <summary>
        /// Renders the object to static HTML.
        /// </summary>
        public abstract Task<string> RenderToStaticMarkup();
    }
}