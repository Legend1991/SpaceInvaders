namespace SpaceInvaders.Core
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        bool Running();
        double Elapsed();
    }
}
