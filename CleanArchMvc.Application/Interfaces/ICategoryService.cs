using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task CreateAsync(CategoryDTO obj);
        Task UpdateAsync(CategoryDTO obj);
        Task RemoveAsync(int? id);
    }
}
