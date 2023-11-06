using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //policy.WithOrigins("https://");
        policy.AllowAnyOrigin(); // Allow all
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// connect db
T2207A_API.Entities.T2207aApiContext.connectionString = builder.Configuration.GetConnectionString("API");
builder.Services.AddDbContext<T2207A_API.Entities.T2207aApiContext>(
    options => options.UseSqlServer(T2207A_API.Entities.T2207aApiContext.connectionString)
    );

// Add Authencation JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

// Add Policy
builder.Services.AddSingleton<IAuthorizationHandler,
                    T2207A_API.Handlers.ValidYearOldHandler>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim(
        ClaimTypes.Email, "admin@gmail.com"));

    options.AddPolicy("Member", policy => policy.RequireClaim(
       ClaimTypes.Email));

    options.AddPolicy("Age18Plus", policy =>policy.AddRequirements(
        new T2207A_API.Requirements.YearOldRequirements(18,60)
        ));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

