using SpaceInvaders.Core;
using SpaceInvadersSpec.Core;

namespace Core.GameLoopSpec
{
    public class FixedUpdateFrequency
    {
        [TestCase(25,  50, TestName = "Update twice per rendering frame when 25 fps")]
        [TestCase(50,  50, TestName = "One update per rendering frame when 50 fps")]
        [TestCase(100, 50, TestName = "Two rendering frames with one update when 100 fps")]
        public void UpdateFrequencyRemainsTheSameRegardlessOfFPS(int fps, int fixedCallsCount)
        {
            // One extra render cycle is required because the fixed update is skipped during the first one
            var expectedRenderCallsCount = fps + 1;
            var expectedQuitCallsCount   = expectedRenderCallsCount + 1;
            var timestepDelay            = 1000d / fps;
            var expectedElapsed          = timestepDelay * expectedQuitCallsCount;

            var controller = new ControllerFake() { MaxCyclesCount = expectedRenderCallsCount };
            var display    = new DisplaySpy();
            var scene      = new SceneSpy();
            var timestep   = new TimestepFake() { Delay = timestepDelay };
            var game       = new GameLoop(controller, display, scene, timestep);

            game.Run();

            Assert.Multiple(() =>
            {
                Assert.That(timestep.Elapsed(),             Is.EqualTo(expectedElapsed));
                Assert.That(controller.QuitCallsCount,      Is.EqualTo(expectedQuitCallsCount));
                Assert.That(controller.InterruptCallsCount, Is.EqualTo(fixedCallsCount));
                Assert.That(scene.FixedUpdateCallsCount,    Is.EqualTo(fixedCallsCount));
                Assert.That(display.RenderCallsCount,       Is.EqualTo(expectedRenderCallsCount));
            });
        }
    }
}
