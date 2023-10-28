using SpaceInvaders.Core;

using RaylibCS = Raylib_cs.Raylib;
using KeyboardKey = Raylib_cs.KeyboardKey;

namespace SpaceInvaders.Raylib
{
    public class Keyboard<T>(Dictionary<KeyboardKey, T> keyBinding, Dictionary<T, Action> commandBinding) : Controller where T : notnull
    {
        public event Action Quit;

        public void Interrupt()
        {
            if (RaylibCS.WindowShouldClose())
            {
                Quit?.Invoke();
            }

            foreach (var (key, command) in keyBinding)
            {
                if (RaylibCS.IsKeyDown(key) && commandBinding.TryGetValue(command, out var action))
                {
                    action();
                }
            }
        }
    }
}
