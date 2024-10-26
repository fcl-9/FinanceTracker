using FinanceTracker.Api.Infrastructure;
using FinanceTracker.Api.Infrastructure.Repositories;
using FinanceTracker.Api.Mapper;
using FinanceTracker.Api.Model;
using FinanceTracker.Controllers;
using FinanceTracker.Infrastructure.FinanceTracker.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IValidator<AccountRequest>, AccountRequestValidator>();
builder.Services.AddScoped<IValidator<MonthlyRecordRequest>, InvestmentRequestValidator>();

// Add SQLite connection
builder.Services.AddDbContext<FinanceTrackerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AccountProfile), typeof(InvestmentProfile));

// Register repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IMonthlyRecordRepository, MonthlyRecordRepository>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();