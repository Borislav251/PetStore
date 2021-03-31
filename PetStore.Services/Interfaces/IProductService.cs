using System.Collections.Generic;

using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Services.Interfaces
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);

        ICollection<ListAllProductsServiceModel> GetAll();

        ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);
    }
}
