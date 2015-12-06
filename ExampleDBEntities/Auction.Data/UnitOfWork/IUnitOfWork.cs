using Auction.Data.Repository;

namespace Auction.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void Commit();
    }
}
