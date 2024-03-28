using RaylibCS = Raylib_cs.Raylib;
using ConfigFlags = Raylib_cs.ConfigFlags;
using Color = Raylib_cs.Color;

namespace SpaceInvaders.Raylib
{
    public class Display : Core.Display
    {
        private readonly List<Sprite> sprites = new();

        public Display()
        {
            RaylibCS.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            RaylibCS.InitWindow(Width, Height, "Space Invaders");
            RaylibCS.SetWindowIcon(RaylibCS.LoadImage(Assets.FaeyanSprite));
        }

        public void Add(Sprite sprite)
        {
            sprites.Add(sprite);
        }

        public void Remove(Sprite sprite)
        {
            sprites.Remove(sprite);
        }

        public void Render()
        {
            RaylibCS.BeginDrawing();
            RaylibCS.ClearBackground(Color.BLACK);

            foreach (var sprite in sprites)
            {
                sprite.Draw();
            }

            RaylibCS.DrawFPS(0, 0);
            RaylibCS.EndDrawing();
        }

        public int Width  { get => 755; }
        public int Height { get => 750; }
    }
}
