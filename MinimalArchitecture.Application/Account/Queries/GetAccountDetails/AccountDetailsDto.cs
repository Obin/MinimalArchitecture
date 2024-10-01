using System;

namespace MinimalArchitecture.Application.Account.Queries.GetAccountDetails
{
    public class AccountDetailsDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}