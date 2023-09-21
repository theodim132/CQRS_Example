using CQRS_Example.Domain;
using MediatR;
namespace CQRS_Example.Application.Commands
{
    public sealed record CreateItemCommand(string Name) : IRequest;
}
