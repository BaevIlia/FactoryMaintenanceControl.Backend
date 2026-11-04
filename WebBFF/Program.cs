using Refit;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebBFF.Infrastructure.Services.Auth;
using WebBFF.Infrastructure.Services.RestClients.Auth;
using WebBFF.Infrastructure.Services.User;
using WebBFF.Services.Requests;
using WebBFF.Services.RestClients.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

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

var key = builder.Configuration.GetSection("JwtOptions").GetSection("SecretKey").Value;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)),
            
            NameClaimType = ClaimTypes.NameIdentifier,
            RoleClaimType = ClaimTypes.Role,
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddRefitClient<IRequestServiceRestClient>().ConfigureHttpClient(x=>x.BaseAddress = new Uri("http://localhost:5122"));
builder.Services.AddRefitClient<IAuthServiceRestClient>().ConfigureHttpClient(x=>x.BaseAddress = new Uri("http://localhost:5124"));

builder.Services.AddScoped<IRequestsService, RequestsService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddMaps(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("TestPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
