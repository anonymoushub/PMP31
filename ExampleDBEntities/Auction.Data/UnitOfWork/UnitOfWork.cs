using System;
using Auction.Data.Repository;

namespace Auction.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly AuctionDbContext _auctionDbContext;

        public UnitOfWork()
        {
            _auctionDbContext = new AuctionDbContext();
        }

        public void Commit()
        {
            _auctionDbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {

            if (!this._disposed)
            {
                if (disposing)
                {
                    _auctionDbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //--------------------------------
        // REPOSITORIES
        //--------------------------------
        private IUserRepository _userRepository;

        public IUserRepository UserRepository {
            get { return _userRepository ?? (_userRepository = new UserRepository(_auctionDbContext)); }
        }

        private IAuctionRepository _auctionRepository;

        public IAuctionRepository AuctionRepository
        {
            get { return _auctionRepository ?? (_auctionRepository = new AuctionRepository(_auctionDbContext)); }
        }
    }
}
