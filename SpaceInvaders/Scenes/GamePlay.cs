using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Raylib;

namespace SpaceInvaders.Scenes
{
    using CommandBinding = Dictionary<UserCommand, Action>;

    public class GamePlay : Scene
    {
        private readonly Spaceship spaceship;
        private readonly Blaster blaster;

        public GamePlay(IDisplay display, ITimestep timestep) : base(display)
        {
            // TODO: rid off from Textures and Sprites dependencies
            var beamMask = Textures.Mask(Sprites.LaserBeam);
            var spaceshipCollider = display.AddEntity(Sprites.Spaceship);

            spaceshipCollider.Y = 600;
            spaceshipCollider.X = display.Width / 2;

            spaceship = new Spaceship(spaceshipCollider, 0, display.Width);
            blaster = new Blaster(beamMask, spaceshipCollider, GunSlot.TopCenter, timestep);

            blaster.LaserBeamEmited += OnBlasterShot;
        }

        public CommandBinding CommandBinding
        {
            get => new()
            {
                { UserCommand.MoveLeft,  spaceship.Left  },
                { UserCommand.MoveRight, spaceship.Right },
                { UserCommand.Shoot,     blaster.Trigger }
            };
        }

        private void OnBlasterShot(LaserBeam laserBeam)
        {
            AddRigidbody(laserBeam);
            display.AddEntity(Sprites.LaserBeam, laserBeam.Collider);
        }
    }
}
