using System.Diagnostics;

namespace SpaceInvaders.Core
{
    public class Timestep : ITimestep
    {
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();

        public double Elapsed()
        {
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
