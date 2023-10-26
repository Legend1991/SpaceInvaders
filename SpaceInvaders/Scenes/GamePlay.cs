using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Scenes
{
    using CommandBinding = Dictionary<Command, Action>;

    public class GamePlay : Scene
    {
        private readonly SpaceshipFactory spaceshipFactory;
        private readonly AlienFactory alienFactory;

        private CommandBinding input = new();
        private Score score = new();

        public GamePlay(IDisplay display, SpaceshipFactory spaceshipFactory, AlienFactory alienFactory) : base(display)
        {
            this.spaceshipFactory = spaceshipFactory;
            this.alienFactory = alienFactory;

            SpawnSpaceship();
            SpawnIntruders();
        }

        private void SpawnSpaceship()
        {
            var spaceship = spaceshipFactory.Make(display.Width / 2, 700, display.Width);

            AddRigidbody(spaceship.Blaster);

            input.Add(Command.MoveLeft,  spaceship.Left);
            input.Add(Command.MoveRight, spaceship.Right);
            input.Add(Command.Shoot,     spaceship.Blaster.Trigger);

            spaceship.Blaster.OnShot += bullet =>
            {
                AddRigidbody(bullet);

                bullet.OnHit<Alien>(alien =>
                {
                    score.Enroll(alien.Value);
                    alien.Destroy();
                });
                bullet.OnHit<Obstacle>(obstacle => obstacle.Crumble());

            };

            spaceship.Destroyed += GameOver;
        }

        public CommandBinding CommandBinding
        {
            get => input;
        }

        private void GameOver()
        {
            Console.WriteLine("Game over!");
        }

        private void SpawnIntruders()
        {
            var sprites = new AlienType[]
            {
                AlienType.Peleng, AlienType.Gaal, AlienType.Gaal, AlienType.Faeyan, AlienType.Faeyan
            };

            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 11; column++)
                {
                    int x = 75 + column * 55;
                    int y = 110 + row * 55;
                    SpawnAlien(sprites[row], x, y);
                }
            }
        }

        private void SpawnAlien(AlienType type, int x, int y)
        {
            var alien = alienFactory.Make(type, x, y);

            AddRigidbody(alien);
            AddRigidbody(alien.Blaster);

            alien.Blaster.OnShot += bullet =>
            {
                AddRigidbody(bullet);

                bullet.OnHit<Spaceship>(spaceship => spaceship.Damage());
                bullet.OnHit<Obstacle>(obstacle => obstacle.Crumble());
            };
        }
    }
}
