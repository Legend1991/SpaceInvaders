using SpaceInvaders.Core;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Models
{
    public class Bullet(CellCollider collider, Direction direction) : IRigidbody
    {
        private readonly GenericDelegate events = new();
        private readonly int speed = direction == Direction.Down ? 7 : -7;

        public void OnHit<T>(Action<T> action)
        {
            events.Add(action);
        }

        public void HitSomething<T>(T other)
        {
            events.Invoke(other);
        }

        public void Update()
        {
            collider.Y += speed;
        }

        public CellCollider Collider
        {
            get => collider;
        }
    }
}
