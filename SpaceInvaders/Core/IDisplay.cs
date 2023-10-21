namespace SpaceInvaders.Core
{
    public interface IDisplay
    {
        void Render();
        void AddEntity(IEntity entity);

        int Width { get; }
        int Height { get; }
    }
}
