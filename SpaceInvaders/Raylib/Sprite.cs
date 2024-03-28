using SpaceInvaders.Core;

using RaylibCS = Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
using Texture2D = Raylib_cs.Texture2D;

namespace SpaceInvaders.Raylib
{
    public class Sprite
    {
        private Texture2D texture;
        private readonly CellularCollider collider;

        public Sprite(string spriteFileName, CellularCollider collider)
        {
            texture = Textures.Load(spriteFileName);
            this.collider = collider;
        }

        public void Draw()
        {
            RaylibCS.DrawTexture(texture, collider.X, collider.Y, Color.WHITE);

            foreach (var cell in collider.DisabledCells)
            {
                RaylibCS.DrawPixel(collider.X + cell.X, collider.Y + cell.Y, Color.BLACK);
            }
        }
    }
}
