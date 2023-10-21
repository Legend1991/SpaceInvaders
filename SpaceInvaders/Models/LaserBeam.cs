using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public enum VDirection
    {
        Up, Down
    }

    public class LaserBeam(CellCollider collider, VDirection direction) : IRigidbody
    {
        private readonly int speed = direction == VDirection.Down ? 10 : -10;

        public void Update()
        {
            if (collider.Y + collider.Width > 0)
            {
                collider.Y += speed;
            }
        }

        public CellCollider Collider
        {
            get => collider;
        }
    }
}
