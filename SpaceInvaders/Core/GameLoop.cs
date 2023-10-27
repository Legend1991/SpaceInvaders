namespace SpaceInvaders.Core
{
    public class GameLoop(IController controller, IDisplay display, Physics physics, Timestep timestep)
    {
        public void Run()
        {
            timestep.Init();

            while (timestep.Tick())
            {
                while (timestep.FixedTick())
                {
                    controller.Interrupt();
                    physics.FixedUpdate();
                }

                display.Render();
            }
        }
    }
}
