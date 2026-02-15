using AuthService.Application.Events;
using AuthService.Application.Tools.Dto;
using AuthService.Application.Tools.Impl;
using AuthService.Application.Tools.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Repositories.Implementations;
using AuthService.Domain.Repositories.Interfaces;
using AuthService.Infrastructure;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Serialization.Json;
using Shared.EventBus;
using System.Collections;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<AuthDbContext>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AutoRegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenProvider, JwtProvider>();

builder.Services.AddRebus(cfg => cfg.Transport(t =>
                                    t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMQ"), "auth.service.queue").InputQueueOptions(q =>
                                    {
                                        q.SetDurable(true);
                                        q.SetAutoDelete(false);
                                    })
                                    .ExchangeNames
                                    (
                                        directExchangeName: "auth.service.exchange"
                                        )
                                    )
                                    .Serialization(s => s.ConfigureSerializer())
                                    .Routing(r => r.TypeBased().Map<InternalUserCreatedEvent>("user.created.event.queue"))
                                    .Options(o =>
                                    {
                                        o.SetNumberOfWorkers(1);
                                        o.SetMaxParallelism(1);
                                        o.LogPipeline(true);
                                    })); 

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
