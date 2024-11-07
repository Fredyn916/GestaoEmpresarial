using GestaoEmpresarial.Data.Repository;
using GestaoEmpresarial.Entidades.DTO;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Informa ao Swagger para incluir o arquivo XML gerado
    var xmlFile = "GestaoEmpresarial.xml"; // Nome do arquivo XML gerado
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestão Empresarial",
        Version = "v1",
        Description = "Sistema voltado ao suporte de serviços empresariais"
    });
});
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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestão Empresarial");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
