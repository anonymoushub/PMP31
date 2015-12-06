namespace Auction.Data.Repository
{
    public interface IRepository<out T>
    {
        T GetById(int id);
    }
}
