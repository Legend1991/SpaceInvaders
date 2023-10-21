using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public enum GunSlot
    {
        TopCenter, BottomCenter
    }

    public class Blaster(bool[,] laserBeamMask, CellCollider attachment, GunSlot gunSlot, ITimestep timestep)
    {
        public event Action<LaserBeam>? LaserBeamEmited;
        private readonly double reloadTime = 400;
        private double lastShootingTime = 0;

        public void Trigger()
        {
            if (Reloaded())
            {
                var beam = EmitLaserBeam();
                LaserBeamEmited?.Invoke(beam);
            }
        }

        public bool Reloaded()
        {
            var now = timestep.Elapsed();
            if (now - lastShootingTime >= reloadTime)
            {
                lastShootingTime = now;
                return true;
            }
            return false;
        }

        private LaserBeam EmitLaserBeam()
        {
            var collider = new CellCollider(laserBeamMask);
            collider.Y = attachment.Y;
            collider.X = attachment.X + attachment.Width / 2 - collider.Width / 2;

            var direction = gunSlot == GunSlot.TopCenter ? VDirection.Up : VDirection.Down;
            return new LaserBeam(collider, direction);
        }

        public double ReloadingProgress()
        {
            var now = timestep.Elapsed();
            var delta = Math.Clamp(now - lastShootingTime, 0, reloadTime);
            return delta / reloadTime;
        }
    }
}
