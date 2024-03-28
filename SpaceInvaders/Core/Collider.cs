namespace SpaceInvaders.Core
{
    public interface Collider
    {
        public bool Hits(Collider other);
    }
}
