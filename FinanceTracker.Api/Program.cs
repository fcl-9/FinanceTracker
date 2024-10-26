using FinanceTracker.Api.Infrastructure;
using FinanceTracker.Api.Infrastructure.Repositories;
using FinanceTracker.Api.Mapper;
using FinanceTracker.Api.Model;
using FinanceTracker.Api.Model.Requests;
using FinanceTracker.Api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

//TODO: STANDARDIZE RESPONSES OUT OF THE API USING PROBLEM DETAILS WHEN THE API RETURNS 4XX, 5XX
//TODO: ADD OPEN TELEMETRY FOR LOGGING + METRICS + TRACE COLLECTION

var builder = WebApplication.CreateBuilder(args);

// Add Fluent Validators
builder.Services.AddScoped<IValidator<AccountRequest>, AccountRequestValidator>();
builder.Services.AddScoped<IValidator<InvestmentRecordRequest>, InvestmentRequestValidator>();

// Add SQLite connection
builder.Services.AddDbContext<FinanceTrackerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add Automapper
builder.Services.AddAutoMapper(typeof(AccountProfile), typeof(InvestmentProfile));

// Register repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IInvestmentRepository, InvestmentRepository>();

// builder.Services.AddProblemDetails();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }
//TODO: DISABLED FOR DEV PURPOSES
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();