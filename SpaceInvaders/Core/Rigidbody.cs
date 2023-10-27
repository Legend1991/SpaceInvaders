namespace SpaceInvaders.Core
{
    public class Rigidbody
    {
        private readonly GenericDelegate hit = new();

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
                        return;
                    }
                }
            }
        }

        public CellularCollider Collider { get; set; }
    }
}
