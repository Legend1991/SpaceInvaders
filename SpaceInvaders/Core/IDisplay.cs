namespace SpaceInvaders.Core
{
    public interface IDisplay
    {
        void Render();

        int Width { get; }
        int Height { get; }
    }
}
