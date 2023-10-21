using SpaceInvaders.Models;

namespace Models.LivesCounterSpec
{
    public class LivesCount
    {
        [Test]
        public void Initialial()
        {
            var counter = new LivesCounter(3);

            Assert.Multiple(() =>
            {
                Assert.That(counter.Lives, Is.EqualTo(3));
                Assert.That(counter.GameOver, Is.EqualTo(false));
            });
        }

        [Test]
        public void DecreaseOnce()
        {
            var counter = new LivesCounter(3);

            counter.Decrease();

            Assert.Multiple(() =>
            {
                Assert.That(counter.Lives, Is.EqualTo(2));
                Assert.That(counter.GameOver, Is.EqualTo(false));
            });
        }

        [Test]
        public void DecreaseTwice()
        {
            var counter = new LivesCounter(3);

            counter.Decrease();
            counter.Decrease();

            Assert.Multiple(() =>
            {
                Assert.That(counter.Lives, Is.EqualTo(1));
                Assert.That(counter.GameOver, Is.EqualTo(false));
            });
        }

        [Test]
        public void DecreaseThreeTimes()
        {
            var counter = new LivesCounter(3);

            counter.Decrease();
            counter.Decrease();
            counter.Decrease();

            Assert.Multiple(() =>
            {
                Assert.That(counter.Lives, Is.EqualTo(0));
                Assert.That(counter.GameOver, Is.EqualTo(true));
            });
        }

        [Test]
        public void DecreaseFourTimes()
        {
            var counter = new LivesCounter(3);

            counter.Decrease();
            counter.Decrease();
            counter.Decrease();
            counter.Decrease();

            Assert.Multiple(() =>
            {
                Assert.That(counter.Lives, Is.EqualTo(0));
                Assert.That(counter.GameOver, Is.EqualTo(true));
            });
        }
    }
}
