using SpaceInvaders.Core;
using SpaceInvaders.Models;

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
            var laserBeamMask     = Raylib.Textures.Mask(Sprites.LaserBeam);
            var spaceshipMask     = Raylib.Textures.Mask(Sprites.Spaceship);
            var spaceshipCollider = new CellCollider(spaceshipMask);
            var spaceshipEntity   = new Raylib.Entity(Sprites.Spaceship, spaceshipCollider);

            display.AddEntity(spaceshipEntity);

            spaceshipCollider.Y = 600;
            spaceshipCollider.X = display.Width / 2;

            spaceship = new Spaceship(spaceshipCollider, 0, display.Width);
            blaster   = new Blaster(laserBeamMask, spaceshipCollider, GunSlot.TopCenter, timestep);

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
            var laserBeamEntity = new Raylib.Entity(Sprites.LaserBeam, laserBeam.Collider);
            display.AddEntity(laserBeamEntity);
        }
    }
}
