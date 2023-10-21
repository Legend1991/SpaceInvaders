using SpaceInvaders.Core;

namespace SpaceInvadersSpec.Core
{
    public class ControllerFake : IController
    {
        public int MaxCyclesCount = 1;
        public int QuitCallsCount = 0;
        public int InterruptCallsCount = 0;

        public void Interrupt()
        {
            InterruptCallsCount++;
        }

        public bool Quit()
        {
            QuitCallsCount++;
            return QuitCallsCount > MaxCyclesCount;
        }
    }
}
