using FluxoCaixa.Application.Applications;
using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Context;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Data.Repository;
using FluxoCaixa.Services.Interfaces;
using FluxoCaixa.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Applications
builder.Services.AddScoped<IContaApplication, ContaApplication>();
builder.Services.AddScoped<ITransacaoApplication, TransacaoApplication>();
builder.Services.AddScoped<ITipoTransacaoApplication, TipoTransacaoApplication>();

//Repositories
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<ITipoTransacaoRepository, TipoTransacaoRepository>();

//Services
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<FluxoContext>();
builder.Services.AddAutoMapper(typeof(Program));

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
