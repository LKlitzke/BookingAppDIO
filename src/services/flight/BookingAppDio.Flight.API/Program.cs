using BookingAppDio.Bus;
using BookingAppDio.Core.EFCore;
using BookingAppDio.Core.Generators;
using BookingAppDio.Core.Jwt;
using BookingAppDio.Core.Web;
using BookingAppDio.Core.Mapping;
using BookingAppDio.Core.Options;
using BookingAppDio.Flight.API;
using BookingAppDio.Flight.API.Extensions;
using BookingAppDio.Flight.Infra.Context;
using BookingAppDio.Flight.Infra.Seed;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var env = builder.Environment;

var appOptions = builder.Services.GetOptions<AppOptions>("AppOptions");

builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly(typeof(FlightDbContext).Assembly.GetName().Name)
));

builder.Services.AddScoped<IDataSeeder, FlightDataSeeder>();

builder.Services.AddJwt();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(FlightRoot).Assembly));
builder.Services.AddCustomMapster(typeof(FlightRoot).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(FlightRoot).Assembly);
builder.Services.AddHttpContextAccessor();

builder.Services.AddCustomMassTransit(configuration, typeof(FlightRoot).Assembly);
SnowFlakIdGenerator.Configure(1);

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseMigrations();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); 

app.MapGet("/", x => x.Response.WriteAsync(appOptions.Name));

app.Run();
