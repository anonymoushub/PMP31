using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public interface IAuctionRepository : IRepository<Model.Auction>
    {
        IQueryable<Model.Auction> GetAllAuctions();
        IQueryable<Model.Auction> GetApprovedAuctions();
    }
}
