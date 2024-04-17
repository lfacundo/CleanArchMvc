using AutoMapper;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;
        protected readonly IMapper _mapper;

        public ServiceBase(IRepositoryBase<T> repoBase, IMapper mapper)
        {
            _repositoryBase = repoBase;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var all = await _repositoryBase.GetAllAsync();
            return _mapper.Map<IEnumerable<T>>(all);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            var entity = await _repositoryBase.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        public async Task CreateAsync(T obj)
        {
            var entity = _mapper.Map<T>(obj);
            await _repositoryBase.CreateAsync(entity);
        }

        public async Task RemoveAsync(int? id)
        {
            var entity = _repositoryBase.GetByIdAsync(id).Result;
            await _repositoryBase.RemoveAsync(entity);
        }

        public async Task UpdateAsync(T obj)
        {
            var entity = _mapper.Map<T>(obj);
            await _repositoryBase.RemoveAsync(entity);
        }
    }
}
