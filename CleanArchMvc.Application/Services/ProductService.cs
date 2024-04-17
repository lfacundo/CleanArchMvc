using AutoMapper;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _repository = productRepo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var all = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(all);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var all = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(all);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productEntity = await _repository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task CreateAsync(ProductDTO obj)
        {
            var entity = _mapper.Map<Product>(obj);
            await _repository.CreateAsync(entity);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(ProductDTO obj)
        {
            var entity = _mapper.Map<Product>(obj);
            await _repository.RemoveAsync(entity);
        }
    }
}
