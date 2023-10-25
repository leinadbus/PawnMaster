using PawnMaster.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using PawnMaster.API.Services;
using PawnMaster.Persistence.Repositories;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Configuración de la conexión a la BD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});


builder.Services.AddScoped<InterfazUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<InterfazPartidaRepository, PartidaRepository>();

//Autenticación
var key = builder.Configuration.GetValue<string>("JwtSettings:Key");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//Autorización

builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(

    options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description =
            "Autenticación JWT usando el esquema Bearer. \r\n\r\n" +
            "Ingresa la palabra 'Bearer' seguida de un [espacio], despues su token en el campo de abajo \r\n\r\n" +
            "Ejemplo: \"Bearer tkmfkdkjfnkjgnkdjfngkjfd\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    }
    );
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
