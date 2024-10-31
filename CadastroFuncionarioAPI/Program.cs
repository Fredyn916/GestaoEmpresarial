using GestaoEmpresarial.Data.Repository;
using GestaoEmpresarial.Entidades.DTO;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));
InicializadorDB.Inicializar();

builder.Services.AddScoped<IAcaoRepository, AcaoRepository>();
builder.Services.AddScoped<IBalancoRepository, BalancoRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IEconomiaRepository, EconomiaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddScoped<IAcaoService, AcaoService>();
builder.Services.AddScoped<IBalancoService, BalancoService>();
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IEconomiaService, EconomiaService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

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
