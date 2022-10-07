using Domain.Infrastructure.services;
using Domain.Models;
using MongoDB.Bson.Serialization;
using MV.Framework.interfaces;
using MV.Framework.providers;
using NorthWind.Infrastructure;
using NorthWind.Infrastructure.Config;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyHeader().AllowAnyMethod();
                      });
});
/*********************mongo section******************/
var config = new WsConfig(@"./appsettings.json");

var mongoContext = ConfigHelper.GetMongoContext(config);
var register = new MongoServiceInstanceRegister();
//save services in the register
foreach (string sp in mongoContext.MongoSettings.Services)
{
    string className = sp;
    var service = MongoServiceFactory.GetMongoService(mongoContext, className);
    register.SetServiceInstance(service, className);//this seems to work
    //builder.Services.AddSingleton<IMongoService>(sp => service);  
}
builder.Services.AddScoped(r => register);
config.DefaultMongoSettings = mongoContext.MongoSettings;
builder.Services.AddScoped(c => config);
/********************end of mongo section***********/

builder.Services.AddControllers();
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

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();

//BsonClassMap.RegisterClassMap<Orders>();
//BsonClassMap.RegisterClassMap<OrderDetails>();
//BsonClassMap.RegisterClassMap<Customers>();
