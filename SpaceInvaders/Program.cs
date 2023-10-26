using Raylib_cs;
using SpaceInvaders.Models;

namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<KeyboardKey, Command> keyBinding = new()
            {
                { KeyboardKey.KEY_LEFT,  Command.MoveLeft  },
                { KeyboardKey.KEY_RIGHT, Command.MoveRight },
                { KeyboardKey.KEY_SPACE, Command.Shoot     }
            };

            var display          = new Raylib.Display();
            var spaceshipFactory = new Raylib.Factories.SpaceshipFactory(display);
            var alienFactory     = new Raylib.Factories.AlienFactory(display);
            var scene            = new Scenes.GamePlay(display, spaceshipFactory, alienFactory);
            var controller       = new Raylib.Keyboard<Command>(keyBinding, scene.CommandBinding);
            var stopwatch        = new System.Stopwatch();
            var timestep         = new Core.Timestep(stopwatch);
            var game             = new Core.GameLoop(controller, display, scene, timestep);

            controller.Quit += stopwatch.Stop;

            game.Run();
        }
    }
}
