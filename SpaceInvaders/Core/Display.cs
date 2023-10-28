namespace SpaceInvaders.Core
{
    public interface Display
    {
        void Render();

        int Width { get; }
        int Height { get; }
    }
}
