using SpaceInvaders.Core;

using RaylibCS = Raylib_cs.Raylib;
using ConfigFlags = Raylib_cs.ConfigFlags;
using Color = Raylib_cs.Color;

namespace SpaceInvaders.Raylib
{
    public class Display : IDisplay
    {
        private readonly List<IEntity> entities = new();

        public Display()
        {
            RaylibCS.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            RaylibCS.InitWindow(Width, Height, "SpaceInvaders");
        }

        public void AddEntity(IEntity entity)
        {
            var raylibEntity = (Entity)entity;
            raylibEntity.Init();
            entities.Add(raylibEntity);
        }

        public void Render()
        {
            RaylibCS.BeginDrawing();
            RaylibCS.ClearBackground(Color.BLACK);

            foreach (var entity in entities)
            {
                entity.Draw();
            }

            RaylibCS.DrawFPS(0, 0);
            RaylibCS.EndDrawing();
        }

        public int Width  { get => 755; }
        public int Height { get => 750; }
    }
}
