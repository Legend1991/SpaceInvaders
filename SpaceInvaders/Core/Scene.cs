namespace SpaceInvaders.Core
{
    public class Scene(IDisplay display) : IScene
    {
        protected readonly IDisplay display = display;
        private readonly List<IRigidbody> rigidbodies = new();

        public void AddRigidbody(IRigidbody body)
        {
            rigidbodies.Add(body);
        }

        public void FixedUpdate()
        {
            foreach (var body in rigidbodies.ToList())
            {
                body.Update();
            }
        }
    }
}
