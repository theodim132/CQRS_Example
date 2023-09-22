using CQRS_Example.Application.Queries;
using CQRS_Example.Domain.Entities.Products;
using CQRS_Example.Domain.Interfaces;
using CQRS_Example.Infrastructure.Repositories;
using MediatR;

namespace CQRS_Example.Application.Handlers
{
    public class GetProductByIdHandlder : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandlder(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken0) =>
             await _productRepository.GetProductByIdAsync(request.Id);
    }
}
