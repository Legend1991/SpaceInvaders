using DotNet = System.Diagnostics;

namespace SpaceInvaders.System
{
    public class Stopwatch : Core.Stopwatch
    {
        private readonly DotNet.Stopwatch stopwatch = new();

        public void Start()
        {
            stopwatch.Start();
        }

        public double Elapsed()
        {
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public bool IsRunning()
        {
            return stopwatch.IsRunning;
        }
    }
}
