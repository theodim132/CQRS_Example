using MediatR;

namespace CQRS_Example.Application.Commands
{
    internal sealed class CreateItemCommandHanlder : IRequestHandler<CreateItemCommand>
    {
        Task IRequestHandler<CreateItemCommand>.Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
