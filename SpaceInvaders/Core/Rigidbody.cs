namespace SpaceInvaders.Core
{
    public class Rigidbody
    {
        public event Action? Destroyed;

        private readonly TypedAction hit = new();

        public virtual void FixedUpdate() {}

        public virtual void Update(double deltaTime) {}

        public void OnHit<T>(Action<T> action)
        {
            hit.Add(action);
        }

        public void CheckCollisions(Physics physics)
        {
            if (Collider == null) return;

            foreach (var typeName in hit.TypesNames)
            {
                foreach (var other in physics.RigidbodiesBy(typeName))
                {
                    if (other.Collider == null) continue;

                    if (Collider.Hits(other.Collider))
                    {
                        hit.Invoke(other);
                        hit.RemoveFor(typeName);
                        Hit();
                    }

                    if (Exists == false)
                    {
                        return;
                    }
                }
            }
        }

        public void Destroy()
        {
            Exists = false;
            Destroyed?.Invoke();
        }

        protected virtual void Hit() {}

        public CellularCollider? Collider { get; set; }

        public bool Exists { get; private set; } = true;
    }
}
