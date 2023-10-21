using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class DisplaySpy : IDisplay
    {
        public int RenderCallsCount = 0;

        public int Width => 0;
        public int Height => 0;

        public void AddEntity(IEntity entity)
        {
        }

        public void Render()
        {
            RenderCallsCount++;
        }
    }
}
