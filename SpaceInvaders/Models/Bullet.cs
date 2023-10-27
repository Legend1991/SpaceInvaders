using SpaceInvaders.Core;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Models
{
    public class Bullet(Direction direction) : Rigidbody
    {
        private readonly int speed = direction == Direction.Down ? 7 : -7;

        public override void FixedUpdate()
        {
            Collider.Y += speed;
        }
    }
}
