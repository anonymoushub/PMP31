using Auction.Web.ViewModels;

namespace Auction.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Model.User, UserViewModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Model.Product, ProductViewModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Model.UserRole, UserRoleViewModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Model.Auction, AuctionViewModel>().ReverseMap();
        }
    }
}