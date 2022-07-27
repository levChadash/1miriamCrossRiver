
using CoronaApp.Api.Middlewares;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.Services.AddDbContext<CoronaAppContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("connectionDBMiriam")));
builder.Services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "Volunteer", Version = "v1" });
              c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
              {
                  Name = "Authorization",
                  Type = SecuritySchemeType.ApiKey,
                  Scheme = "Bearer",
                  BearerFormat = "JWT",
                  In = ParameterLocation.Header,
                  Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
              });
              c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
              });
          });
              builder.Services.AddScoped<IDalLocation, DalLocation>();
              builder.Services.AddScoped<IDalPatient, DalPatient>();
              builder.Services.AddScoped<ILocationRespository, LocationRespository>();
              builder.Services.AddScoped<IPatientRespository, PatientRespository>();
              builder.Services.AddScoped<IDalUser, DalUser>();
              builder.Services.AddScoped<IUserRespository, UserRespository>();
              builder.Services.AddControllers();
              var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("key").Value);
              builder.Services.AddAuthentication(x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(x =>
              {

                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = builder.Configuration["Jwt:Audience"],
                      ValidIssuer = builder.Configuration["Jwt:Issuer"],
                  };
              });

              builder.Services.AddEndpointsApiExplorer();

              IConfigurationRoot configuration = new
                    ConfigurationBuilder().AddJsonFile("appsettings.json",
                    optional: false, reloadOnChange: true).Build();
              Log.Logger = new LoggerConfiguration().ReadFrom.Configuration
                          (configuration).CreateLogger();
              var app = builder.Build();
              if (app.Environment.IsDevelopment())
              {
                  app.UseSwaggerUI(c =>
                  {
                      c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoronaApp");
                      c.RoutePrefix = "swagger";
                  });
                  app.UseSwagger();
              }

              app.UseHandleErrorMiddleware();
              app.UseAuthentication();
              app.UseHttpsRedirection();
              app.UseAuthorization();
              app.MapControllers();
              app.Run();
     
public partial class Program { }