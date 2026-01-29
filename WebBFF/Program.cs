using Refit;
using System.Reflection;
using WebBFF.Services.Requests;
using WebBFF.Services.RestClients.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.AddRefitClient<IRequestServiceRestClient>().ConfigureHttpClient(x=>x.BaseAddress = new Uri("http://localhost:5122"));

builder.Services.AddScoped<IRequestsService, RequestsService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
