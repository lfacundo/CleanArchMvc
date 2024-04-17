using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService : IServiceBase<Product>
    {
        Task<ProductDTO> GetProductCategoryAsync(int? id);
    }
}
