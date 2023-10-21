namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var timestep   = new Core.Timestep();
            var display    = new Raylib.Display();
            var scene      = new Scenes.GamePlay(display);
            var controller = new Raylib.Keyboard(scene.CommandBinding);
            var game       = new Core.GameLoop(controller, display, scene, timestep);

            game.Run();
        }
    }
}
