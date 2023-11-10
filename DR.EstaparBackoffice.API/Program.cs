using DR.EstaparBackoffice.Domain.Data;
using DR.EstaparBackoffice.Domain.Repository.Interfaces;
using DR.EstaparBackoffice.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using DR.EstaparBackoffice.API.Authentication;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddDbContext<DRxEstaparDBContext>(options =>
{
    // Ajuste na string de conexão para ignorar a validação do certificado
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase") + ";TrustServerCertificate=True", options => options.EnableRetryOnFailure());

});


builder.Services.AddScoped<IEstaparRepository, EstaparRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ConfigureServices
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isProduction = environment == Environments.Production;
var isDevelopment = environment == Environments.Development;

builder.Configuration.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

var app = builder.Build();

// Configuração de Ambiente
if (app.Environment.IsDevelopment())
{
    builder.Environment.EnvironmentName = "Development";
    app.UseSwagger();
    app.UseSwaggerUI();

}
else
{
    builder.Environment.EnvironmentName = "Production";
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(myAllowSpecificOrigins);

app.MapControllers();

app.Run();