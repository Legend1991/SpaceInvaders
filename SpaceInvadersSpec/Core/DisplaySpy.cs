using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class DisplaySpy : IDisplay
    {
        public int RenderCallsCount = 0;

        public int Width => 0;
        public int Height => 0;

        public void AddEntity(string spriteFileName, CellCollider collider)
        {
        }

        public CellCollider AddEntity(string spriteFileName)
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            RenderCallsCount++;
        }
    }
}
