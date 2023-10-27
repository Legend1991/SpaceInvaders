using SpaceInvaders.Core;
using SpaceInvaders.Models;
using SpaceInvaders.Models.Factories;

namespace SpaceInvaders.Scenes
{
    using CommandBinding = Dictionary<Command, Action>;

    public class GamePlay
    {
        private readonly SpaceshipFactory spaceshipFactory;
        private readonly AlienFactory alienFactory;

        private CommandBinding input = new();
        private Score score = new();

        public GamePlay(SpaceshipFactory spaceshipFactory, AlienFactory alienFactory)
        {
            this.spaceshipFactory = spaceshipFactory;
            this.alienFactory = alienFactory;

            SpawnSpaceship();
            SpawnIntruders();
        }

        private void SpawnSpaceship()
        {
            var spaceship = spaceshipFactory.Make(0.5f, 0.9f);

            input.Add(Command.MoveLeft,  spaceship.Left);
            input.Add(Command.MoveRight, spaceship.Right);
            input.Add(Command.Shoot,     spaceship.Blaster.Trigger);

            spaceship.Blaster.OnShot += bullet =>
            {
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
            var aliens = new AlienType[]
            {
                AlienType.Peleng, AlienType.Gaal, AlienType.Gaal, AlienType.Faeyan, AlienType.Faeyan
            };

            for (int row = 0; row < aliens.Length; row++)
            {
                for (int column = 0; column < 11; column++)
                {
                    var x = 0.115f + column * 0.07f;
                    var y = 0.115f + row * 0.07f;
                    SpawnAlien(aliens[row], x, y);
                }
            }
        }

        private void SpawnAlien(AlienType type, float x, float y)
        {
            var alien = alienFactory.Make(type, x, y);

            alien.Blaster.OnShot += bullet =>
            {
                bullet.OnHit<Spaceship>(spaceship => spaceship.Damage());
                bullet.OnHit<Obstacle>(obstacle => obstacle.Crumble());
            };
        }
    }
}
