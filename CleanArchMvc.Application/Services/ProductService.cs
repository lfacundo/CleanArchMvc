using AutoMapper;
using CleanArchMvc.Application.DTO_s;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded!");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productsByIdQuery = new GetProductByIdQuery(id.Value);

            if (productsByIdQuery == null)
                throw new Exception($"Error");

            var result = await _mediator.Send(productsByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productsByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productsByIdQuery == null)
        //        throw new Exception($"Error");

        //    var result = _mediator.Send(productsByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task CreateAsync(ProductDTO obj)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(obj);
            await _mediator.Send(productCreateCommand);
        }

        public async Task RemoveAsync(int? id)
        {
            var removeProduct = new ProductRemoveCommand(id.Value);

            if (removeProduct == null)
                throw new Exception($"Error");

            var result = await _mediator.Send(removeProduct);
        }

        public async Task UpdateAsync(ProductDTO obj)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(obj);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
