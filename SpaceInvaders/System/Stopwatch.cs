using DotNet = System.Diagnostics;
using SpaceInvaders.Core;

namespace SpaceInvaders.System
{
    public class Stopwatch : IStopwatch
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

        public bool Running()
        {
            return stopwatch.IsRunning;
        }
    }
}
