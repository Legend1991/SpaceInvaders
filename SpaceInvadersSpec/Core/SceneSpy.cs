using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class SceneSpy : IScene
    {
        public int FixedUpdateCallsCount = 0;

        public void AddRigidbody(IRigidbody body)
        {
        }

        public void FixedUpdate()
        {
            FixedUpdateCallsCount++;
        }
    }
}
