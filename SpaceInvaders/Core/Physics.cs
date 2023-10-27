namespace SpaceInvaders.Core
{
    public class Physics
    {
        private readonly List<IRigidbody> rigidbodies = new();

        public void Add(IRigidbody body)
        {
            rigidbodies.Add(body);
        }

        public void Remove(IRigidbody body)
        {
            rigidbodies.Remove(body);
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < rigidbodies.Count; ++i)
            {
                var body = rigidbodies[i];
                body.FixedUpdate();
            }
        }
    }
}
