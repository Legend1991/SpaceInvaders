namespace SpaceInvaders.Core
{
    using Rigidbodies = List<Rigidbody>;

    public class Physics
    {
        // The fixed timestep of the physics system in milliseconds [20ms = 50fps]
        public static readonly double FixedDeltaTime = 20;

        private readonly Dictionary<string, Rigidbodies> registry = [];

        public void Add(Rigidbody body)
        {
            var typeName = body.GetType().FullName;
            if (typeName != null)
            {
                if (registry.TryGetValue(typeName, out Rigidbodies? value))
                {
                    value.Add(body);
                }
                else
                {
                    registry.Add(typeName, [body]);
                }
            }
        }

        public Rigidbodies RigidbodiesBy(string typeName)
        {
            if (registry.TryGetValue(typeName, out var rigidbodies))
            {
                return rigidbodies;
            }
            return [];
        }

        public void Remove(Rigidbody body)
        {
            var typeName = body.GetType().FullName;
            if (typeName != null && registry.TryGetValue(typeName, out var rigidbodies))
            {
                rigidbodies.Remove(body);

                if (rigidbodies.Count == 0)
                {
                    registry.Remove(typeName);
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

        public void Update(double deltaTime)
        {
            foreach (var body in Rigidbodies)
            {
                body.Update(deltaTime);
                body.CheckCollisions(this);
            }
        }

        private Rigidbodies Rigidbodies
        {
            get => registry.Values.SelectMany(x => x).ToList();
        }
    }
}
