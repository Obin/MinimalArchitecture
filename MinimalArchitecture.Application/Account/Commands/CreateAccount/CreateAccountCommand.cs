using MediatR;
using OperationResult;
using System;
using System.Threading;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace MinimalArchitecture.Application.Account.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Result<Guid, string>>
    {
        public string Email { get; set; } = string.Empty;
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<Guid, string>>
    {
        public CreateAccountCommandHandler()
        {
        }

        public async Task<Result<Guid, string>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return Ok(Guid.NewGuid());
        }
    }
}