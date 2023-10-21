using SpaceInvaders.Raylib;

namespace Raylib.TexturesSpec
{
    public class ReadCollisionMask
    {

        [Test]
        public void FromSprite()
        {
            bool[,] mask = Textures.Mask(@"..\..\..\..\SpaceInvaders\Assets\Sprites\spaceship.png");

            Assert.Multiple(() =>
            {
                Assert.That(mask.GetLength(0), Is.EqualTo(28));
                Assert.That(mask.GetLength(1), Is.EqualTo(44));
                Assert.That(mask[26, 42],      Is.True);
                Assert.That(mask[26, 43],      Is.False);
            });
        }
    }
}
