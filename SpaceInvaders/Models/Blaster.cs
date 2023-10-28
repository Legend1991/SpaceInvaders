using SpaceInvaders.Core;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Models
{
    public enum GunSlot
    {
        TopCenter, BottomCenter
    }

    public class Blaster(BulletFactory bulletFactory, CellularCollider ownerCollider, GunSlot gunSlot) : Rigidbody
    {
        public event Action<Bullet>? OnShot;

        private int ticksToReload = 0;

        public void Trigger()
        {
            if (Exists && Reloaded())
            {
                var bullet = CreateBulllet();
                OnShot?.Invoke(bullet);
                ticksToReload = 40;
            }
        }

        public bool Reloaded()
        {
            return ticksToReload <= 0;
        }

        public override void FixedUpdate()
        {
            ticksToReload = Math.Clamp(ticksToReload - 1, 0, ticksToReload);
        }

        private Bullet CreateBulllet()
        {
            var y = ownerCollider.Y;
            y += gunSlot == GunSlot.TopCenter ? 0 : ownerCollider.Height;
            var x = ownerCollider.X + ownerCollider.Width / 2;

            var direction = gunSlot == GunSlot.TopCenter
                ? Direction.Up
                : Direction.Down;

            return bulletFactory.Make(direction, x, y);
        }
    }
}
