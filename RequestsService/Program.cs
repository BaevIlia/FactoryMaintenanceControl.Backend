using Rebus.Config;
using Rebus.Serialization.Json;
using RequestsService.Domain.Repositories.Implementations;
using RequestsService.Domain.Repositories.Interfaces;
using RequestsService.Infrastructure;
using System.Reflection;
using Shared.EventBus;
using RequestsService.Application.Events;

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

builder.Services.AddRebus(cfg => cfg.Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMQ"), "user.created.event.queue"))
                                    .Options(o =>
                                    {
                                        o.SetNumberOfWorkers(1);
                                        o.SetMaxParallelism(1);
                                        o.LogPipeline(true);
                                    })
                                    .Serialization(s => s.ConfigureSerializer())
                                    );

builder.Services.AutoRegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<RequestDbContext>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var hanlerType = typeof(InternalUserCreatedEvent.Handler);

Console.WriteLine($"{hanlerType != null}");

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
