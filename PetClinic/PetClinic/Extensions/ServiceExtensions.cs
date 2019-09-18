using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PetClinic.Core.Models.Identity;
using PetClinic.Data.Models.Identity;
using PetClinic.Data.Repositories;
using PetClinic.Data.Repositories.EntityFramework;
using PetClinic.Data.Services;
using PetClinic.Data.Services.Interfaces;
using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.Extensions
{
    public static class ServiceExtensions
    {
        private static AppSettings _appSettings;

        public static void AddClinicServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IVeterinarianService, VeterinarianService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
        }

        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            _appSettings = appSettingsSection.Get<AppSettings>();
        }

        public static void AddClinicAuthenticationServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });
            services.AddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddScoped<ApplicationUserStore>();

            if (_appSettings == null || _appSettings.Secret == null)
            {
                throw new Exception("AppSettings Secret not found");
            }

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
