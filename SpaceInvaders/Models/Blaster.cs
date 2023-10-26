using SpaceInvaders.Core;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Models
{
    public enum GunSlot
    {
        TopCenter, BottomCenter
    }

    public class Blaster(BulletFactory bulletFactory, CellCollider attachment, GunSlot gunSlot) : IRigidbody
    {
        public event Action<Bullet>? OnShot;
        private int ticksToReload = 0;

        public void Trigger()
        {
            if (Reloaded())
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

        private Bullet CreateBulllet()
        {
            var y = gunSlot == GunSlot.TopCenter
                ? attachment.Y
                : attachment.Y + attachment.Height;
            var x = attachment.X + attachment.Width / 2;

            var direction = gunSlot == GunSlot.TopCenter
                ? Direction.Up
                : Direction.Down;

            return bulletFactory.Make(direction, x, y);
        }

        public void Update()
        {
            ticksToReload = Math.Clamp(ticksToReload - 1, 0, ticksToReload);
        }
    }
}
