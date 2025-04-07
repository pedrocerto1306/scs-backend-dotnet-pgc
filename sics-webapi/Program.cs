using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using sics_webapi.Data;
using sics_webapi.Models;
using sics_webapi.Models.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder => 
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<DataContext>(
    context => context.UseMySql(builder.Configuration.GetConnectionString("ConexaoSicsDb"), new MySqlServerVersion(new Version(11, 4, 4)))
);

//Identity
builder.Services.AddAuthentication();   //Quem você é?
builder.Services.AddAuthorization();    //O que você pode fazer

builder.Services
    .AddIdentityApiEndpoints<SicsUsuario>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

app.MapIdentityApi<SicsUsuario>();          //Adiciona os endpoints do identity core

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();