using AutoMapper;
using FinanceTracker.Api.Model;
using FinanceTracker.Infrastructure;

namespace FinanceTracker.Api.Mapper;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountRequest, Account>();
        CreateMap<Account, AccountResponse>();
    }
}