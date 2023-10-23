namespace SpaceInvaders.Core
{
    public interface IScene
    {
        void FixedUpdate();
        void AddRigidbody(IRigidbody body);
        void RemoveRigidbody(IRigidbody body);
    }
}
