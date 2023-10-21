using RaylibCS = Raylib_cs.Raylib;
using Texture2D = Raylib_cs.Texture2D;

namespace SpaceInvaders.Raylib
{
    public static class Textures
    {
        private static readonly Dictionary<string, Texture2D> cache = new();

        public static Texture2D Load(string fileName)
        {
            if (cache.ContainsKey(fileName))
            {
                return cache[fileName];
            }

            var texture = RaylibCS.LoadTexture(fileName);
            cache[fileName] = texture;

            return texture;
        }

        static public bool[,] Mask(string fileName)
        {
            var image = RaylibCS.LoadImage(fileName);
            var mask  = new bool[image.height, image.width];

            for (int x = 0; x < image.width; x++)
            {
                for (int y = 0; y < image.height; y++)
                {
                    var color = RaylibCS.GetImageColor(image, x, y);
                    mask[y, x] = color.a == 255;
                }
            }

            return mask;
        }
    }
}
