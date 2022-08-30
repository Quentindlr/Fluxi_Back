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
//builder.Services.AddScoped<BaseRepository<Utilisateur>, UtilisateurRepository>();
builder.Services.AddScoped<BaseRepository<Video>, VideoRepository>();
builder.Services.AddDbContext<DataContextService>();

builder.Services.AddTransient<IUpload, UploadService>();
builder.Services.AddScoped<ILogin, JwtLoginService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("react", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

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

builder.Services.AddAuthorization(builder =>
{
    builder.AddPolicy("admin", options =>
    {
        options.RequireRole("admin");
    });

    builder.AddPolicy("user", options =>
    {
        options.RequireRole("user");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseStaticFiles();
app.UseCors("react");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
