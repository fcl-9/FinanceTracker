using AutoMapper;
using FinanceTracker.Api.Model;
using FinanceTracker.Api.Model.Database;
using FinanceTracker.Api.Model.Requests;
using FinanceTracker.Api.Model.Response;

namespace FinanceTracker.Api.Mapper;

public class InvestmentProfile : Profile
{
    public InvestmentProfile()
    {
        CreateMap<MonthlyRecordRequest, MonthlyRecord>();
        CreateMap<MonthlyRecord, InvestmentResponse>();
    }
}