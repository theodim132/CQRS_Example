using CQRS_Example.Domain.Entities.Products;
using MediatR;

namespace CQRS_Example.Application.Queries
{
    //Inside the <> of the IRequest we define the return value from the handler 
    public sealed record GetProductByIdQuery(int Id) : IRequest<Product>;
}
