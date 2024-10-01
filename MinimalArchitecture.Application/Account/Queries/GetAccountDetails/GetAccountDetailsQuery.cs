using MediatR;
using OperationResult;
using System;
using System.Threading;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace MinimalArchitecture.Application.Account.Queries.GetAccountDetails
{
    public class GetAccountDetailsQuery : IRequest<Result<AccountDetailsDto, string>>
    {
    }

    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, Result<AccountDetailsDto, string>>
    {
        public GetAccountDetailsQueryHandler()
        {
        }

        public async Task<Result<AccountDetailsDto, string>> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            var accountDetailsDto = new AccountDetailsDto
            {
                Id = Guid.NewGuid(),
                Email = "Email"
            };

            return Ok(accountDetailsDto);
        }
    }
}