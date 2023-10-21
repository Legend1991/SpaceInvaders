using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class TimestepFake : ITimestep
    {
        public double Delay = 20;
        private double elapsed = 0;

        public double Elapsed()
        {
            double r = elapsed;
            elapsed += Delay;
            return r;
        }
    }
}
