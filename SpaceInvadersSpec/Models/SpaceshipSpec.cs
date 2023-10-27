using Core.CellColliderSpec;
using SpaceInvaders.Core;
using SpaceInvaders.Models;

namespace Models.SpaceshipSpec
{
    internal class MoveHorizontally
    {
        [Test]
        public void Left()
        {
            var collider = new CellularCollider(Fixtures.Mask2) { X = 1, Y = 0 };
            var spaceship = new Spaceship(collider, 0, 5);

            spaceship.Left();

            Assert.Multiple(() =>
            {
                Assert.That(collider.X, Is.EqualTo(0));
                Assert.That(collider.Y, Is.EqualTo(0));
            });
        }

        [Test]
        public void Right()
        {
            var collider = new CellularCollider(Fixtures.Mask2) { X = 0, Y = 0 };
            var spaceship = new Spaceship(collider, 0, 5);

            spaceship.Right();

            Assert.Multiple(() =>
            {
                Assert.That(collider.X, Is.EqualTo(1));
                Assert.That(collider.Y, Is.EqualTo(0));
            });
        }
    }

    internal class PreventOutOfBoundary
    {
        [Test]
        public void Left()
        {
            var collider = new CellularCollider(Fixtures.Mask2) { X = 0, Y = 0 };
            var spaceship = new Spaceship(collider, 0, 4);

            spaceship.Left();

            Assert.Multiple(() =>
            {
                Assert.That(collider.X, Is.EqualTo(0));
                Assert.That(collider.Y, Is.EqualTo(0));
            });
        }

        [Test]
        public void Right()
        {
            var collider = new CellularCollider(Fixtures.Mask2) { X = 1, Y = 0 };
            var spaceship = new Spaceship(collider, 0, 5);

            spaceship.Right();

            Assert.Multiple(() =>
            {
                Assert.That(collider.X, Is.EqualTo(1));
                Assert.That(collider.Y, Is.EqualTo(0));
            });
        }
    }
}
