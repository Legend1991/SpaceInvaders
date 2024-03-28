using System.Diagnostics;

namespace SpaceInvaders.Core
{
    public class CellularCollider(bool[,] mask, bool fragile = false) : Collider
    {
        private static readonly int AXIS_X = 1;
        private static readonly int AXIS_Y = 0;

        private readonly bool[,] mask = mask;
        private readonly bool fragile = fragile;

        private int x0 = 0;
        private int y0 = 0;
        private int x1 = mask.GetLength(AXIS_X);
        private int y1 = mask.GetLength(AXIS_Y);

        private readonly List<Vector2> disabledCells = [];

        public bool Hits(Collider other)
        {
            if (other is not CellularCollider) return false;

            if (Overlaps((CellularCollider)other))
            {
                return TestOverlappingArea((CellularCollider)other);
            }

            return false;
        }

        private bool Overlaps(CellularCollider other)
        {
            return x0 < other.x1 && y0 < other.y1 && x1 >= other.x0 && y1 >= other.y0;
        }

        private bool TestOverlappingArea(CellularCollider other)
        {
            bool hits = false;

            int startX = Math.Max(x0, other.x0);
            int startY = Math.Max(y0, other.y0);

            int endX = Math.Min(x1, other.x1);
            int endY = Math.Min(y1, other.y1);

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    int thisX = x - x0;
                    int thisY = y - y0;

                    int otherX = x - other.x0;
                    int otherY = y - other.y0;

                    if (mask[thisY, thisX] && other.mask[otherY, otherX])
                    {
                        hits = true;

                        if (fragile)
                        {
                            mask[thisY, thisX] = false;
                            disabledCells.Add(new Vector2(thisX, thisY));
                        }

                        if (other.fragile)
                        {
                            other.mask[otherY, otherX] = false;
                            other.disabledCells.Add(new Vector2(otherX, otherY));
                        }
                    }
                }
            }

            return hits;
        }

        public int X
        {
            get => x0;
            set
            {
                x0 = value;
                x1 = value + mask.GetLength(AXIS_X);
            }
        }

        public int Y
        {
            get => y0;
            set
            {
                y0 = value;
                y1 = value + mask.GetLength(AXIS_Y);
            }
        }

        public int Width { get => mask.GetLength(AXIS_X); }

        public int Height { get => mask.GetLength(AXIS_Y); }

        public List<Vector2> DisabledCells { get => disabledCells; }
    }
}
