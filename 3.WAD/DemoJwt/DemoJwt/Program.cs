using DemoJwt.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//builder .Service.Add Controller
builder.Services.AddAuthentication(o =>
{ o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(b=> {
    b.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();



//app.MapControllers();
app.MapGet("/security/message",()=>"Welcome To ").RequireAuthorization();
app.MapPost("/security/login", [AllowAnonymous] (MyUser user) =>
{
    if (user.Username == "aptech" && user.Password == "123")
    {
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new[]
            {
                new Claim("Id",Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                new Claim(JwtRegisteredClaimNames.Email,user.Username),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);
        var jwtToken = tokenHandler.WriteToken(token);
        var strinToken = tokenHandler.WriteToken(token);
        return Results.Ok(strinToken);
    }
    return Results.Unauthorized();
});
// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();
app.Run();
