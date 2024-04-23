using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    return await _entity.Include(c => c.Category)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //}
        public new async Task<Product> GetByIdAsync(int? id)
        {
           return await _entity.Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
