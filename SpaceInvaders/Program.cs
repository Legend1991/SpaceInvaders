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
            var physics          = new Core.Physics();
            var spaceshipFactory = new Raylib.Factories.SpaceshipFactory(display, physics);
            var alienFactory     = new Raylib.Factories.AlienFactory(display, physics);
            var obstacleFactory  = new Raylib.Factories.ObstacleFactory(display, physics);
            var scene            = new Scenes.GamePlay(spaceshipFactory, alienFactory, obstacleFactory);
            var controller       = new Raylib.Keyboard<Command>(keyBinding, scene.CommandBinding);
            var stopwatch        = new System.Stopwatch();
            var timestep         = new Core.Timestep(stopwatch, Core.Physics.FixedDeltaTime);
            var game             = new Core.GameLoop(controller, display, physics, timestep);

            controller.Quit += stopwatch.Stop;

            game.Run();
        }
    }
}
