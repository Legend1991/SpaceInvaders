using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public enum GunSlot
    {
        TopCenter, BottomCenter
    }

    public class Blaster(bool[,] laserBeamMask, CellCollider attachment, GunSlot gunSlot) : IRigidbody
    {
        public event Action<LaserBeam>? LaserBeamEmited;
        private int ticksToReload = 0;

        public void Trigger()
        {
            if (Reloaded())
            {
                var beam = EmitLaserBeam();
                LaserBeamEmited?.Invoke(beam);
                ticksToReload = 40;
            }
        }

        public bool Reloaded()
        {
            return ticksToReload <= 0;
        }

        private LaserBeam EmitLaserBeam()
        {
            var collider = new CellCollider(laserBeamMask);
            collider.Y = gunSlot == GunSlot.TopCenter
                ? attachment.Y
                : attachment.Y + attachment.Height - collider.Height;
            collider.X = attachment.X + attachment.Width / 2 - collider.Width / 2;

            var direction = gunSlot == GunSlot.TopCenter
                ? VDirection.Up
                : VDirection.Down;

            return new LaserBeam(collider, direction);
        }

        public void Update()
        {
            ticksToReload = Math.Clamp(ticksToReload - 1, 0, ticksToReload);
        }
    }
}
