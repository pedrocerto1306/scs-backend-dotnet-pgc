using Sics.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Pintura", "Mecânica", "Faxina", "Motorista", "Babá", "Cuidador(a)", "Contador(a)"
};

app.MapGet("/servicos", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new SicsServicos
        (
            index % 3 == 0 ? EnumSicsCotacoes.Euro : index % 2 == 0 ? EnumSicsCotacoes.Dolar : EnumSicsCotacoes.Real,
            index % 3 == 1 ? 100 : index % 2 == 0 ? 150 : 300,
            summaries[index]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetServicosSics")
.WithOpenApi();

app.Run();


record SicsServicos(EnumSicsCotacoes? cotacao, float precoCotacaoOriginal, string? nome)
{
    public float precoReal = cotacao switch
    {
        EnumSicsCotacoes.Euro => precoCotacaoOriginal * 7,
        EnumSicsCotacoes.Dolar => precoCotacaoOriginal * 6,
        EnumSicsCotacoes.Real => precoCotacaoOriginal,
        _ => throw new NotImplementedException("Cotacao aplicada não existe no sistema sics.")
    };
}
