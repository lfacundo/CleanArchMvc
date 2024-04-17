using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var all = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(all);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var all = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(all);
        }

        public async Task CreateAsync(CategoryDTO obj)
        {
            var entity = _mapper.Map<Category>(obj);
            await _repository.CreateAsync(entity);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(CategoryDTO obj)
        {
            var entity = _mapper.Map<Category>(obj);
            await _repository.RemoveAsync(entity);
        }
    }
}
