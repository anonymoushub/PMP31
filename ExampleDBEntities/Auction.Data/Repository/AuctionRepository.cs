using System.Linq;
using System.Data.Entity;
using Auction.Model;

namespace Auction.Data.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionDbContext _auctionDbContext;
        public AuctionRepository(AuctionDbContext auctionDbContext)
        {
            _auctionDbContext = auctionDbContext;
        }

        public Model.Auction GetById(int id)
        {
            return _auctionDbContext.Auctions.Include(u => u.Product)
                                             .FirstOrDefault(u => u.Id == id);
        }

        public IQueryable<Model.Auction> GetAllAuctions()
        {
            return _auctionDbContext.Auctions;
        }

        public IQueryable<Model.Auction> GetApprovedAuctions()
        {
            return _auctionDbContext.Auctions.Where(a => a.Approved);
        }
    }
}
