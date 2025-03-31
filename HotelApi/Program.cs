using System.Text;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using HotelApi.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Application.Validators;
using FluentValidation;
using Infrastructure.Interfaces;
using Infrastructure.Respositories;
namespace HotelApi
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HotelApiContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HotelApiContext")
            ?? throw new InvalidOperationException("Connection string 'HotelApiContext' not found."),
            b => b.MigrationsAssembly("Infrastructure")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IBookingServices, BookingService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IBookingRepository, BookingRespository>();
            builder.Services.AddControllers();

            // Enables server-side auto-validation
            builder.Services.AddFluentValidationAutoValidation();

            // Enables client-side validation (optional)
            builder.Services.AddFluentValidationClientsideAdapters();
            // Registers validators from assembly

            builder.Services.AddValidatorsFromAssemblyContaining<BookingRequestDtoValidator>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add Security Definition
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer <your_token>'"
                });

                // Add Security Requirement
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] {}
                    }
                });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["AppSettings:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddControllers();
            builder.Services.AddScoped<IAuthService, AuthService>();

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
        }
    }
}
