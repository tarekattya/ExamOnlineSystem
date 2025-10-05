

using ExamOnlineSystem.Application.Auth;
using ExamOnlineSystem.Infrastructure.Auth;
using ExamOnlineSystem.Infrastructure.Persistence;
using ExamOnlineSystem.Shared.Auth;
using ExamOnlineSystem.Shared.Errors;
using ExamOnlineSystem.Shared.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExamOnlineSystem.API
{
    public static class DependanceInjection
    {

       
        public static IServiceCollection AddApplicationServices(this IServiceCollection services ,IConfiguration configuration,WebApplicationBuilder webApplication)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddValidtionResponse(webApplication);
            services.AddIdentity(configuration);


            services.AddDBServices(configuration);
            return services;
        }

        public static IServiceCollection AddDBServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options/*.UseLazyLoadingProxies()*/.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

            return services;
        }


        public static IServiceCollection AddIdentity(this IServiceCollection services , IConfiguration configuration)
        {

            
            services.Configure<jwtSettings>(configuration.GetSection("Jwt"));
            services.AddSingleton<IJwtProvider, JwtProvider>();

            var jwtSettings = configuration.GetSection("Jwt").Get<jwtSettings>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                
            }
            )

                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }


            ).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.Key)),

                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience

                };
                });

            return services;
        }


        public static IServiceCollection AddValidtionResponse(this IServiceCollection services , WebApplicationBuilder webApplication)
        {
            webApplication.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value!.Errors.Count > 0)
                        .SelectMany(x => x.Value!.Errors)
                        .Select(x => x.ErrorMessage).ToList();

                    var errorResponse = new ApiValidationResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
