using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entity;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<T> CreateAsync(T obj)
        {
            _entity.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            _entity.Update(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<T> RemoveAsync(T obj)
        {
            _entity.Remove(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
