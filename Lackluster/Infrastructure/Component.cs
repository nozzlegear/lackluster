using System.Threading.Tasks;
using Lackluster.Elements;

namespace Lackluster.Infrastructure
{
    public abstract partial class Component : BaseObject
    {
        /// <summary>
        /// Renders the component to static HTML.
        /// </summary>
        public override async Task<string> RenderToStaticMarkup()
        {
            // Because all components implement this method, we just
            // need to call Render once and let the element render
            // itself. No need for tree traversal.
            var child = await Render();

            return await child.RenderToStaticMarkup();
        }

        public abstract Task<BaseObject> Render();
    }
}