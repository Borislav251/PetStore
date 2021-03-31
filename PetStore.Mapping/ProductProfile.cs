using AutoMapper;

using PetStore.Models;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel,
                Product>();
            this.CreateMap<Product,
                ListAllProductsByProductTypeServiceModel>();
        }


    }
}
