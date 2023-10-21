using SpaceInvaders.Core;

namespace Core.CellColliderSpec
{
    public class Fixtures
    {
        public static readonly bool[,] Mask1 = {
            { true },
            { true }
        };
        public static readonly bool[,] Mask2 = {
            { false, false, false, false },
            { false, true,  true,  false },
            { false, true,  true,  false },
            { false, false, false, false }
        };
    }

    public class ColliderMissesOtherCollider
    {
        [Test]
        public void WhenCollidersDiverge()
        {
            var collider1 = new CellCollider(Fixtures.Mask1);
            var collider2 = new CellCollider(Fixtures.Mask2);

            collider1.X = 4;

            Assert.Multiple(() =>
            {
                Assert.That(collider1.Hits(collider2), Is.False);
                Assert.That(collider2.Hits(collider1), Is.False);
            });
        }

        [Test]
        public void WhenBodiesDiverge()
        {
            var collider1 = new CellCollider(Fixtures.Mask1);
            var collider2 = new CellCollider(Fixtures.Mask2);

            Assert.Multiple(() =>
            {
                Assert.That(collider1.Hits(collider2), Is.False);
                Assert.That(collider2.Hits(collider1), Is.False);
            });
        }
    }

    public class ColliderHitsOtherCollider
    {
        [Test]
        public void WhenBodiesOverlap()
        {
            var collider1 = new CellCollider(Fixtures.Mask1);
            var collider2 = new CellCollider(Fixtures.Mask2);

            collider1.X = 1;

            Assert.Multiple(() =>
            {
                Assert.That(collider1.Hits(collider2), Is.True);
                Assert.That(collider2.Hits(collider1), Is.True);
            });
        }
    }
}
