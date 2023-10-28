namespace SpaceInvaders.Core
{
    public interface Stopwatch
    {
        void Start();
        void Stop();
        bool IsRunning();
        double Elapsed();
    }
}
