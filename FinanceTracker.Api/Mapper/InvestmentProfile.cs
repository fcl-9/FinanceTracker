using AutoMapper;
using FinanceTracker.Api.Model;
using FinanceTracker.Api.Model.Response;
using FinanceTracker.Infrastructure;

namespace FinanceTracker.Api.Mapper;

public class InvestmentProfile : Profile
{
    public InvestmentProfile()
    {
        CreateMap<MonthlyRecordRequest, MonthlyRecord>();
        CreateMap<MonthlyRecord, InvestmentResponse>();
    }
}