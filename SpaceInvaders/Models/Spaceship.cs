using SpaceInvaders.Core;

namespace SpaceInvaders.Models
{
    public class Spaceship(int minX, int maxX) : Rigidbody
    {
        private readonly int speed = 10;

        private int lives = 3;

        public void Left()
        {
            var nextX = Collider.X - speed;
            Collider.X = Math.Clamp(nextX, minX, Collider.X);
        }

        public void Right()
        {
            var nextX = Collider.X + speed;
            Collider.X = Math.Clamp(nextX, Collider.X, maxX - Collider.Width);
        }

        public void Damage()
        {
            lives--;

            if (lives > 0)
            {
                Console.WriteLine("Warning! Your ship has been damaged!");
            }

            if (lives == 0)
            {
                Console.WriteLine("Your ship has been destroyed!");
                Destroy();
                Blaster.Destroy();
            }
        }

        public Blaster Blaster { get; set; }
    }
}
