using JobsFinder.Domain.Extension;
using JobsFinder.Infrastructure.Database;
using JobsFinder.Infrastructure;
using Microsoft.EntityFrameworkCore;
using JobsFinder.Api.Filtros;
using JobsFinder.Application.Servicos.Automapper;
using JobsFinder.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobsFinderContext>(
    options => options.UseNpgsql(builder.Configuration.GetConexaoCompleta())
    );

builder.Services.AddRepositorio(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguracao());
}).CreateMapper());

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

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConexao();
    var nomeDatabase = builder.Configuration.GetNomeDatabase();

    Database.CreateDatabase(conexao, nomeDatabase);
}
