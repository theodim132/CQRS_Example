using CQRS_Example.Application.Queries;
using CQRS_Example.Domain.Entities;
using CQRS_Example.Domain.Interfaces;
using CQRS_Example.Infrastructure.Repositories;
using MediatR;

namespace CQRS_Example.Application.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken) => await _productRepository.GetAllProductsAsync();
    }
}
