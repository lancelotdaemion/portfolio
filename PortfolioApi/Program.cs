using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Portfolio.Api.Model;
using PortfolioApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped(http => new HttpClient());

builder.Services.AddSignalR();

var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntitySet<LoremIpsum>("LoremIpsums");

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

var app = builder.Build();

app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<LoremIpsumHub>("lorem_ipsum_notifications");

//app.UseAuthorization();

app.MapControllers();

app.Run();
