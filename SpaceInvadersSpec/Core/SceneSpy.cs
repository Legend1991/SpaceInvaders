using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class SceneSpy : IScene
    {
        public int FixedUpdateCallsCount = 0;

        public void AddRigidbody(Rigidbody body)
        {
        }

        public void RemoveRigidbody(Rigidbody body)
        {
        }

        public void FixedUpdate()
        {
            FixedUpdateCallsCount++;
        }
    }
}
