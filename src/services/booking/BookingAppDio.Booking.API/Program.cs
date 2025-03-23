using BookingAppDio.Booking.API;
using BookingAppDio.Booking.Domain.Interfaces;
using BookingAppDio.Booking.Infra.Context;
using BookingAppDio.Booking.Infra.Repository;
using BookingAppDio.Bus;
using BookingAppDio.Core.Generators;
using BookingAppDio.Core.Jwt;
using BookingAppDio.Core.Mapping;
using BookingAppDio.Core.Options;
using BookingAppDio.Core.Web;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
var env = builder.Environment;

var appOptions = builder.Services.GetOptions<AppOptions>("AppOptions");


// remover?
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJwt();
SnowFlakIdGenerator.Configure(3);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BookingRoot).Assembly));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomMapster(typeof(BookingRoot).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(BookingRoot).Assembly);
builder.Services.AddCustomMassTransit(configuration, typeof(BookingRoot).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", x => x.Response.WriteAsync(appOptions.Name));

app.Run();
