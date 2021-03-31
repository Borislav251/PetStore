using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class ProductService : IProductService
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

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            var products =
                this.dbContext
                    .Products
                    .ProjectTo<ListAllProductsServiceModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList();

            return products;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels =
                this.dbContext
                    .Products
                    .Where(p => p.ProductType == productType)
                    .ProjectTo<ListAllProductsByProductTypeServiceModel>
                    (this.mapper.ConfigurationProvider)
                    .ToList();

            return productsServiceModels;
        }
    }
}
