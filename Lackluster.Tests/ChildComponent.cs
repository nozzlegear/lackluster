using System.Threading.Tasks;
using Lackluster.Infrastructure;

namespace Lackluster.Tests
{
    public class ChildComponent : Component
    {
        public override Task<BaseObject> Render()
        {
            return Task.FromResult<BaseObject>(
                Div(
                    P(
                        "Hello world! It's your boy the ChildComponent."
                    )
                )
            );
        }
    }
}