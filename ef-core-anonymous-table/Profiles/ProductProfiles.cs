using AutoMapper;
using ef_core_anonymous_table.Controllers;
using ef_core_anonymous_table.Models;

namespace ef_core_anonymous_table.Profiles
{
    public class ProductProfiles :Profile
    {
        public ProductProfiles()
        {
            CreateMap<UpdateProductPriceReq, Product>()
                .ForMember(d => d.Id, s => s.MapFrom(s => s.ID))
                .ForMember(d => d.Price, s => s.MapFrom(s => s.Price));
        }
    }
}
