using CQRS_Example.Application.Commands.ProductCommands;
using CQRS_Example.Domain.Entities;
using CQRS_Example.Domain.Interfaces;
using CQRS_Example.Infrastructure.Repositories;
using MediatR;

namespace CQRS_Example.Application.Handlers
{
    public class UpdateProductHanlder : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHanlder(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
             await _productRepository.UpdateProductAsync(request.updatedProduct);
            return request.updatedProduct;
        }
    }
}
