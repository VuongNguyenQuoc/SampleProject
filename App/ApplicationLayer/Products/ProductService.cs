using App.ApplicationLayer.ModelsDto;
using App.DomainModelLayer.Models;
using App.DomainModelLayer.Products;
using App.DomainModelLayer.Tenants;
using App.Helpers.Repository;
using App.Helpers.Specification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IMapper mapper , IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public ProductDto Add(ProductDto product)
        {
            ISpecification<Product> alreadyTenant = new ProductAlreadySpec(product.Code,product.TenantId);

            Product existingTenant = _productRepository.FindOne(alreadyTenant);
            if (existingTenant != null)
                throw new Exception("Product with this code already exists");
            if (product.Price <0 )
                throw new Exception("Price can not be negative ");
            Product tenant1 = Product.Create(product.Code,product.Tilte,product.Description,product.Price,product.TenantId);
            var result = _productRepository.Add(tenant1);
            _unitOfWork.Commit();
            return _mapper.Map<Product, ProductDto>(result);
        }

       

        ProductDto IProductService.Update(Guid id, string tilte)
        {
            Product existingTenant = _productRepository.FindById(id);
            if (existingTenant == null)
                throw new Exception("Not exists prouct in data");
          
            var result = _productRepository.Update(id,tilte);
            _unitOfWork.Commit();
            return _mapper.Map<Product, ProductDto>(result);
        }
    }
}
