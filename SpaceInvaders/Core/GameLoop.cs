namespace SpaceInvaders.Core
{
    public class GameLoop(IController controller, IDisplay display, IScene scene, ITimestep timestep)
    {
        private readonly double fixedDeltaTime = 20; // The fixed timestep of the physics system [50 fps]

        public void Run()
        {
            var now = timestep.Elapsed();
            var lastUpdate = now;
            var accumulator = 0d;

            while (controller.Quit() == false)
            {
                var delta = now - lastUpdate;
                accumulator += delta;

                while (accumulator >= fixedDeltaTime)
                {
                    controller.Interrupt();
                    scene.FixedUpdate();

                    accumulator -= fixedDeltaTime;
                }

                display.Render();

                lastUpdate = now;
                now = timestep.Elapsed();
            }
        }
    }
}
