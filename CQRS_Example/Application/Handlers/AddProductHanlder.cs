using CQRS_Example.Application.Commands.ProductCommands;
using CQRS_Example.Domain.Entities.Products;
using CQRS_Example.Domain.Interfaces;
using CQRS_Example.Infrastructure.Repositories;
using MediatR;

namespace CQRS_Example.Application.Handlers
{
    internal sealed class AddProductHanlder : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHanlder(IProductRepository productRepository) =>
            _productRepository = productRepository;

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.AddProductAsync(request.Product);
            return request.Product;
        }
    }
}
