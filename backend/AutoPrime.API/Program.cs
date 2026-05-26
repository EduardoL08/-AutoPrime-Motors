using AutoPrime.API.Configurations;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÃO DO MONGODB
// ─────────────────────────────────────────────
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration
        .GetSection("MongoDbSettings")
        .Get<MongoDbSettings>()!;

    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = builder.Configuration
        .GetSection("MongoDbSettings")
        .Get<MongoDbSettings>()!;

    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});


// 2. CONTROLLERS E SERIALIZAÇÃO JSON
// ─────────────────────────────────────────────
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
     
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
    });


// 3. SWAGGER
// ─────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// 4. CORS
// ─────────────────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000", 
                "http://localhost:5173"   
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// PIPELINE HTTP
// ─────────────────────────────────────────────
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
