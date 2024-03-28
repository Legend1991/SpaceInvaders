namespace SpaceInvaders.Core
{
    public class Timestep(Stopwatch stopwatch, double fixedDeltaTime)
    {
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

        public double DeltaTime { get => now - lastUpdate; }
    }
}
