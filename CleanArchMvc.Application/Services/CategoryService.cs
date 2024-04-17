using AutoMapper;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        public CategoryService(IRepositoryBase<Category> categoryDTO, IMapper mapper) : base(categoryDTO, mapper)
        {
        }
    }
}
