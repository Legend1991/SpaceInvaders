﻿using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class ControllerSpy : Controller
    {
        public int MaxCyclesCount = 1;
        public int InterruptCallsCount = 0;

        public void Interrupt()
        {
            InterruptCallsCount++;
        }
    }
}
