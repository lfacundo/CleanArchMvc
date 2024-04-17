using AutoMapper;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepository = productRepo;
        }
        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productEntity = _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }
    }
}
