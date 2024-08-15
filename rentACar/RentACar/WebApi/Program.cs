using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();  //Application Layer Registration Services
builder.Services.AddPersistenceServices(builder.Configuration);  //Persistence Layer Registration Services
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//This if block exists for tests 
//if (app.Environment.IsProduction())  
app.ConfigureCustomExceptionMiddleware(); //This comes from our core.packages

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
