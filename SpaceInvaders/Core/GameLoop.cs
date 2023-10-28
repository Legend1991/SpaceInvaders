namespace SpaceInvaders.Core
{
    public class GameLoop(Controller controller, Display display, Physics physics, Timestep timestep)
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
