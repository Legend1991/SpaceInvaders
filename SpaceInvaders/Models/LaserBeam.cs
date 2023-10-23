using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public enum VDirection
    {
        Up, Down
    }

    public class LaserBeam(CellCollider collider, VDirection direction) : IRigidbody
    {
        private readonly int speed = direction == VDirection.Down ? 7 : -7;

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
