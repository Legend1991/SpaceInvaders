using SpaceInvaders.Core;
using SpaceInvaders.Models;

namespace SpaceInvaders.Scenes
{
    using CommandBinding = Dictionary<UserCommand, Action>;

    public class GamePlay : Scene
    {
        private Spaceship spaceship;
        private Blaster blaster;

        public GamePlay(IDisplay display) : base(display)
        {
            CreateSpaceship();
            CreateAliensArmy();
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

        private void OnSpaceshipBlasterShot(LaserBeam laserBeam)
        {
            AddRigidbody(laserBeam);
            var laserBeamEntity = new Raylib.Entity(Sprites.LaserBeam, laserBeam.Collider);
            display.AddEntity(laserBeamEntity);
        }

        private void OnAlienBlasterShot(LaserBeam laserBeam)
        {
            AddRigidbody(laserBeam);
            var laserBeamEntity = new Raylib.Entity(Sprites.LaserBeam, laserBeam.Collider);
            display.AddEntity(laserBeamEntity);
        }

        private void CreateSpaceship()
        {
            var laserBeamMask     = Raylib.Textures.Mask(Sprites.LaserBeam);
            var spaceshipMask     = Raylib.Textures.Mask(Sprites.Spaceship);
            var spaceshipCollider = new CellCollider(spaceshipMask) { X = display.Width / 2, Y = 700 };
            var spaceshipEntity   = new Raylib.Entity(Sprites.Spaceship, spaceshipCollider);

            display.AddEntity(spaceshipEntity);

            spaceship = new Spaceship(spaceshipCollider, 0, display.Width);
            blaster   = new Blaster(laserBeamMask, spaceshipCollider, GunSlot.TopCenter);

            blaster.LaserBeamEmited += OnSpaceshipBlasterShot;

            AddRigidbody(blaster);
        }

        private void CreateAliensArmy()
        {
            var sprites = new string[]
            {
                Sprites.Alien3, Sprites.Alien2, Sprites.Alien2, Sprites.Alien1, Sprites.Alien1
            };

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 11; column++)
                {
                    int x = 75 + column * 55;
                    int y = 110 + row * 55;
                    CreateAlien(sprites[row], x, y);
                }
            }
        }

        private void CreateAlien(string spriteFileName, int x, int y)
        {
            var laserBeamMask = Raylib.Textures.Mask(Sprites.LaserBeam);
            var alienMask     = Raylib.Textures.Mask(spriteFileName);
            var alienCollider = new CellCollider(alienMask) { X = x, Y = y };
            var alienEntity   = new Raylib.Entity(spriteFileName, alienCollider);
            var blaster       = new Blaster(laserBeamMask, alienCollider, GunSlot.BottomCenter);
            var alien         = new Alien(alienCollider, blaster);

            blaster.LaserBeamEmited += OnAlienBlasterShot;

            AddRigidbody(blaster);
            AddRigidbody(alien);
            display.AddEntity(alienEntity);
        }
    }
}
