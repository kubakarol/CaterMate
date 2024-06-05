using CaterMate_Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(
        builder.Configuration.GetSection(nameof(MongoSettings)));
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));
builder.Services.AddSingleton(s =>
    s.GetRequiredService<IMongoClient>().GetDatabase("catermate"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowIonicApp",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

BsonClassMap.RegisterClassMap<Order>(cm =>
{
    cm.AutoMap();
    cm.SetIgnoreExtraElements(true); // This will ignore any extra elements, including __v
});

var app = builder.Build();
app.UseCors("AllowIonicApp");

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
