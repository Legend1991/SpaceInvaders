using RaylibCS = Raylib_cs.Raylib;
using Texture2D = Raylib_cs.Texture2D;

namespace SpaceInvaders.Raylib
{
    public static class Textures
    {
        private static readonly Dictionary<string, Texture2D> textureCache = new();
        private static readonly Dictionary<string, bool[,]> maskCache = new();

        public static Texture2D Load(string fileName)
        {
            if (textureCache.ContainsKey(fileName))
            {
                return textureCache[fileName];
            }

            var texture = RaylibCS.LoadTexture(fileName);
            textureCache[fileName] = texture;

            return texture;
        }

        static public bool[,] Mask(string fileName)
        {
            if (maskCache.ContainsKey(fileName))
            {
                return maskCache[fileName];
            }

            var mask = LoadMask(fileName);
            maskCache[fileName] = mask;

            return mask;
        }

        static private bool[,] LoadMask(string fileName)
        {
            var image = RaylibCS.LoadImage(fileName);
            var mask = new bool[image.height, image.width];

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
