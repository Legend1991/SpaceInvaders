﻿using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class StopwatchFake(double timestepDelay, int maxCyclesCount) : Stopwatch
    {
        private double elapsed = 0;
        private int cyclesCount = 0;

        public void Start()
        {
        }

        public double Elapsed()
        {
            cyclesCount++;
            double r = elapsed;
            elapsed += timestepDelay;
            return r;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool IsRunning()
        {
            return cyclesCount <= maxCyclesCount;
        }
    }
}
