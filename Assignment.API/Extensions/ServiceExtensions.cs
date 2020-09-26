using Assignment.API.Data.Implementation;
using Assignment.API.Data.Interface;
using Assignment.API.Models.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Assignment.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    //.AllowCredentials()
                    );
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            { });
        }

        public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AssignmentDBContext>(
                     opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsAssembly("Assignment.API.Models")));
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            _ = services.AddScoped<IAuthenticationService, AuthenticationService>();
            _ = services.AddScoped<IUserService, UserService>();
            _ = services.AddScoped<IRoleService, RoleService>();
            _ = services.AddScoped<IMovieService, MovieService>();
            _ = services.AddScoped<IBookingService, BookingService>();
            _ = services.AddScoped<ILogEntryServices, LogEntryServices>();
        }

        public static void ConfigureModelStateValidation(this IServiceCollection services)
        {
            //services.AddMvc(config =>
            //     config.Filters.Add(new ModelStateValidationFilter()))
            //    .AddJsonOptions(options => { options.JsonSerializerOptions.Formatting = Formatting.Indented; });
        }

        public static void ConfigureCacheAttribute(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new ResponseCacheAttribute() { Duration = 0, NoStore = true, Location = ResponseCacheLocation.None });
            });
            services.AddResponseCaching();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Assignment API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });
            return services;
        }

        #region Jwt Authentication
        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "http://Assignment.com",

                ValidateAudience = true,
                ValidAudience = "http://Assignment.com",

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSection:JWtConfig:Key"])),

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            };

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParams;
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
        }
        #endregion

    }
}

