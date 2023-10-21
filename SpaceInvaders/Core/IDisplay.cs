namespace SpaceInvaders.Core
{
    public interface IDisplay
    {
        void Render();
        void AddEntity(string spriteFileName, CellCollider collider);
        CellCollider AddEntity(string spriteFileName);

        int Width { get; }
        int Height { get; }
    }
}
