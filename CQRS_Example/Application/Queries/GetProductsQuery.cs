using CQRS_Example.Domain.Entities.Products;
using MediatR;

namespace CQRS_Example.Application.Queries
{
    public sealed record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
