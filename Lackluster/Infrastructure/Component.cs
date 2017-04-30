using System.Threading.Tasks;
using Lackluster.Elements;

namespace Lackluster.Infrastructure
{
    public abstract class Component : BaseObject
    {
        protected virtual Html Html(params BaseObject[] children)
        {
            return new Html(null, null, null, children);
        }

        protected virtual Element Div(params BaseObject[] children)
        {
            return new Div(null, null, null, children);
        }

        protected virtual Element Head(params BaseObject[] children)
        {
            return new Head(null, null, null, children);
        }

        protected virtual Element Body(params BaseObject[] children)
        {
            return new Body(null, null, null, children);
        }
        protected virtual Element Section(params BaseObject[] children)
        {
            return new Section(null, null, null, children);
        }

        protected virtual Element P(params BaseObject[] children)
        {
            return new Paragraph(null, null, null, children);
        }

        protected virtual Element P(string text)
        {
            return new Paragraph(children: new Text(text));
        }

        protected virtual Element Link(string relType, string href)
        {
            return new Link(relType, href);
        }

        protected virtual Element Meta(string name, string content)
        {
            return new Meta(name, content);
        }

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