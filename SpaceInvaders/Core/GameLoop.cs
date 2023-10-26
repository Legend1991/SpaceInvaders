namespace SpaceInvaders.Core
{
    public class GameLoop(IController controller, IDisplay display, IScene scene, Timestep timestep)
    {
        public void Run()
        {
            timestep.Init();

            while (timestep.Tick())
            {
                while (timestep.FixedTick())
                {
                    controller.Interrupt();
                    scene.FixedUpdate();
                }

                display.Render();
            }
        }
    }
}
