using back_Fluxi.Interfaces;
using back_Fluxi.Models;
using back_Fluxi.Repositories;
using back_Fluxi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<BaseRepository<Categorie>, CategorieRepository>();
builder.Services.AddScoped<BaseRepository<Client>, ClientRepository>();
builder.Services.AddScoped<BaseRepository<Utilisateur>, UtilisateurRepository>();
builder.Services.AddScoped<BaseRepository<Video>, VideoRepository>();
builder.Services.AddDbContext<DataContextService>();

builder.Services.AddScoped<IUpload, UploadService>();
builder.Services.AddScoped<ILogin, JwtLoginService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = "m2i",
        ValidAudience = "m2i",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bonjour je suis la chaine de crypto"))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
