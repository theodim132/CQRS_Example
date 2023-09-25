using CQRS_Example.Application.Notifications;
using CQRS_Example.Domain.Interfaces;
using MediatR;

namespace CQRS_Example.Application.Handlers
{

    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly IProductRepository _productRepository;

        public CacheInvalidationHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _productRepository.EventOccured(notification.Product, "Cache Invalidated");
        }
    }
}
