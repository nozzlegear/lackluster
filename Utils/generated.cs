using Lackluster.Infrastructure;
using Lackluster.Elements;


public class ComponentPartials
{
	protected virtual Element Anchor(params BaseObject[] children)
	{
		return new Anchor(null, null, null, children);
	}

	protected virtual Element Anchor(string text)
	{
		return new Anchor(null, null, null, new Text(text));
	}
}