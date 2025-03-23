using BookingAppDio.Bus;
using BookingAppDio.Core.EFCore;
using BookingAppDio.Core.Mapping;
using BookingAppDio.Core.Options;
using BookingAppDio.Core.Web;
using BookingAppDio.Identity;
using BookingAppDio.Identity.Data.Configuration;
using BookingAppDio.Identity.Data.Context;
using BookingAppDio.Identity.Extensions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var env = builder.Environment;

var appOptions = builder.Services.GetOptions<AppOptions>("AppOptions");

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly(typeof(IdentityContext).Assembly.GetName().Name)
));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomMapster(typeof(IdentityRoot).Assembly);
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IdentityRoot).Assembly));
builder.Services.AddCustomMapster(typeof(IdentityRoot).Assembly);
builder.Services.AddScoped<IDataSeeder, IdentityDataSeeder>();

builder.Services.AddCustomMassTransit(configuration, typeof(IdentityRoot).Assembly);
builder.Services.AddIdentityServer(env);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMigrations();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseIdentityServer();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapGet("/", x => x.Response.WriteAsync(appOptions.Name));

app.Run();
