using CQRS_Example.Domain.Entities.Products;
using MediatR;

namespace CQRS_Example.Application.Commands.ProductCommands
{
    public sealed record AddProductCommand(Product Product) : IRequest<Product>;
}
