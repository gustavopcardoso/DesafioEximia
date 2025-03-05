using Eximia.CreditoConsignado.Cache;
using Eximia.CreditoConsignado.Domain.Repositories;
using Eximia.CreditoConsignado.Domain.Services;
using Eximia.CreditoConsignado.ExternalServices;
using Eximia.CreditoConsignado.ORM;
using Eximia.CreditoConsignado.ORM.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly("Eximia.CreditoConsignado.ORM"));
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var cacheConfig = builder.Configuration.GetConnectionString("CacheConnection");
var connection = ConnectionMultiplexer.Connect(cacheConfig);

builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<IExternalService, ExternalService>();
builder.Services.AddScoped<ICpfFraudeRepository, CpfFraudeRepository>();
builder.Services.AddSingleton<IConnectionMultiplexer>(connection);
builder.Services.AddSingleton<ICacheService, CacheService>();

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
