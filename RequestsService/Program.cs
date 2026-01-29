using RequestsService.Domain.Repositories.Implementations;
using RequestsService.Domain.Repositories.Interfaces;
using RequestsService.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cfg =>
{
    cfg.AddPolicy("TestPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .WithOrigins("http://localhost:5240")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<RequestDbContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddScoped<IRequestRepository, RequestRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("TestPolicy");   

app.UseAuthorization();

app.MapControllers();

app.Run();
