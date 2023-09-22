using MediatR;

namespace CQRS_Example.Application.Commands.ProductCommands
{
    public sealed record DeleteProductCommand(int Id) : IRequest<bool>;
}
