using CQRS_Example.Application.Commands.ProductCommands;
using CQRS_Example.Domain.Interfaces;
using MediatR;

namespace CQRS_Example.Application.Handlers
{
    public class DeleteProductHanlder : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHanlder(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteProductAsync(request.Id, cancellationToken);
        }
    }
}
