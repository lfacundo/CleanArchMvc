using CleanArchMvc.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        //Task<Product> GetProductCategoryAsync(int? id);
    }
}
