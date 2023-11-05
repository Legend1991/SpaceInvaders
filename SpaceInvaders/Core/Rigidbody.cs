namespace SpaceInvaders.Core
{
    public class Rigidbody
    {
        public event Action Destroyed;

        private readonly ClassifiedAction hit = new();

        public Rigidbody()
        {
            Exists = true;
        }

        public virtual void FixedUpdate() {}

        public void OnHit<T>(Action<T> action)
        {
            hit.Add(action);
        }

        public void CheckCollisions(Physics physics)
        {
            foreach (var typeName in hit.TypesNames)
            {
                foreach (var other in physics.RigidbodiesBy(typeName))
                {
                    if (Collider.Hits(other.Collider))
                    {
                        hit.Invoke(other);
                        hit.RemoveFor(typeName);
                        Hit();
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

        protected virtual void Hit()
        {
        }

        public CellularCollider Collider { get; set; }
        public bool Exists { get; private set; }
    }
}
