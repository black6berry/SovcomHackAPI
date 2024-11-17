using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SovcomHackAPI.ActionClass;
using SovcomHackAPI.Interface;
using SovcomHackAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SovcomHackContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddTransient<ICreateUser, CreateUserClass>();
builder.Services.AddTransient<IUserProfile, ViewInfoClientClass>();
builder.Services.AddTransient<IBankAccountClient, BankAccountClientClass>();
builder.Services.AddTransient<IBankAvailable, BankAccAvailableClass>();
builder.Services.AddTransient<ICreditCard, CreditCardClass>();

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c => c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Документация по хакатону SovComHack")
        );
}

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
