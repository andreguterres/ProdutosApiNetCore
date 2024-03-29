using Microsoft.EntityFrameworkCore;
using ProdutosApiNetCore.Data;
using ProdutosApiNetCore.Mappings;
using ProdutosApiNetCore.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AplicationDbContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("COnexaoPadrao"));
});

builder.Services.AddAutoMapper(typeof(EntitiesToDtoMapping));

builder.Services.AddScoped<IPedidos, PedidoRepository>();


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
