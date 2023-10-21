using SpaceInvaders.Core;
using SpaceInvaders.Models;

using RaylibCS = Raylib_cs.Raylib;
using KeyboardKey = Raylib_cs.KeyboardKey;

namespace SpaceInvaders.Raylib
{
    using KeyBinding = Dictionary<KeyboardKey, UserCommand>;
    using CommandBinding = Dictionary<UserCommand, Action>;

    public class Keyboard(CommandBinding commandBinding) : IController
    {
        private readonly KeyBinding keyBinding = new()
        {
            { KeyboardKey.KEY_LEFT,  UserCommand.MoveLeft  },
            { KeyboardKey.KEY_RIGHT, UserCommand.MoveRight },
            { KeyboardKey.KEY_SPACE, UserCommand.Shoot     }
        };

        public void Interrupt()
        {
            foreach (var (key, command) in keyBinding)
            {
                if (RaylibCS.IsKeyDown(key) && commandBinding.TryGetValue(command, out var action))
                {
                    action();
                }
            }
        }

        public bool Quit()
        {
            return RaylibCS.WindowShouldClose();
        }
    }
}
