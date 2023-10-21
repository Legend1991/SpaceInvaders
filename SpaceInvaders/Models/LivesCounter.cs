namespace SpaceInvaders.Models
{
    public class LivesCounter(uint lives)
    {
        public void Decrease()
        {
            lives = Math.Clamp(lives - 1, 0, lives);
        }

        public uint Lives
        {
            get { return lives; }
        }

        public bool GameOver
        {
            get { return lives <= 0; }
        }
    }
}
