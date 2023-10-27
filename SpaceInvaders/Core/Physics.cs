namespace SpaceInvaders.Core
{
    using Rigidbodies = List<Rigidbody>;

    public class Physics
    {
        private readonly Dictionary<string, Rigidbodies> registry = new();

        public void Add(Rigidbody body)
        {
            var typeName = body.GetType().FullName;
            if (typeName != null)
            {
                if (registry.ContainsKey(typeName))
                {
                    registry[typeName].Add(body);
                }
                else
                {
                    registry.Add(typeName, new Rigidbodies { body });
                }
            }
        }

        public Rigidbodies RigidbodiesBy(string typeName)
        {
            if (registry.TryGetValue(typeName, out var rigidbodies))
            {
                return rigidbodies;
            }
            return new();
        }

        public void Remove(Rigidbody body)
        {
            var typeName = body.GetType().FullName;
            if (typeName != null)
            {
                if (registry.TryGetValue(typeName, out var rigidbodies))
                {
                    rigidbodies.Remove(body);
                }
            }
        }

        public void FixedUpdate()
        {
            foreach (var body in Rigidbodies)
            {
                body.FixedUpdate();
                body.CheckCollisions(this);
            }
        }

        private Rigidbodies Rigidbodies
        {
            get => registry.Values.SelectMany(x => x).ToList();
        }
    }
}
