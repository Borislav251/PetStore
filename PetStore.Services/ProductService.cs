using AutoMapper;
using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using System;

namespace PetStore.Services
{
    public class ProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            Product product = this.mapper.Map<Product>(model);

            this.dbContext.Add(product);
            this.dbContext.SaveChanges();
        }

        public void ListAllByProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }
    }
}
