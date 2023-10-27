using SpaceInvaders.Core;

using RaylibCS = Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
using Texture2D = Raylib_cs.Texture2D;

namespace SpaceInvaders.Raylib
{
    public class Sprite(string spriteFileName, CellularCollider collider)
    {
        private Texture2D texture;

        public void Init()
        {
            texture = Textures.Load(spriteFileName);
        }

        public void Draw()
        {
            RaylibCS.DrawTexture(texture, collider.X, collider.Y, Color.WHITE);
        }
    }
}
