namespace SpaceInvaders.Core
{
    public class Timestep(Stopwatch stopwatch)
    {
        // The fixed timestep of the physics system [50 fps]
        private const double fixedDeltaTime = 20;

        private double now = 0;
        private double lastUpdate = 0;
        private double accumulator = 0;

        public void Init()
        {
            stopwatch.Start();
            now = stopwatch.Elapsed();
            lastUpdate = now;
        }

        public bool Tick()
        {
            accumulator += now - lastUpdate;
            lastUpdate = now;
            now = stopwatch.Elapsed();
            return stopwatch.IsRunning();
        }

        public bool FixedTick()
        {
            if (accumulator >= fixedDeltaTime)
            {
                accumulator -= fixedDeltaTime;
                return true;
            }
            return false;
        }
    }
}
