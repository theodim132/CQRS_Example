using CQRS_Example.Domain.Entities.Products;
using MediatR;

namespace CQRS_Example.Application.Notifications
{
    public sealed record ProductAddedNotification(Product Product) : INotification;
}
