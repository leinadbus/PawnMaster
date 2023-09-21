using PawnMaster.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PawnMaster.API.Services;
using PawnMaster.Persistence.Repositories;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using Microsoft.AspNet.Identity.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//Configuraci�n de la conexi�n a la BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});

//builder.Services.AddIdentity<Usuario, IdentityRole>().AddUserStore<ApplicationDbContext>();
    //.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<InterfazUsuarioRepository, UsuarioRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

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