using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        //Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task<ProductDTO> GetByIdAsync(int? id);
        Task CreateAsync(ProductDTO obj);
        Task UpdateAsync(ProductDTO obj);
        Task RemoveAsync(int? id);
    }
}
