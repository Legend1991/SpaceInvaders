namespace SpaceInvaders.Models
{
    public class Score
    {
        private int value = 0;

        public void Enroll(int change)
        {
            value += change;
            Console.WriteLine("Score: " + value);
        }
    }
}
