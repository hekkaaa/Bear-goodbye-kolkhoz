using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Business.Services.Interfaces;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BearGoodbyeKolkhozProject.API.Extensions
{
    public static class IServiceProviderExtension
    {
        public static void RegisterProjectService(this IServiceCollection services)
        {

            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITrainingReviewService, TrainingReviewService>();
            services.AddScoped<ILecturerService, LecturerService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IContactLecturerService, ContactLecturerService>();
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IAuthService, AuthService>();

        }

        public static void RegisterProjectRepository(this IServiceCollection repository)
        {
            repository.AddScoped<IContactLecturerRepository, ContactLecturerRepository>();
            repository.AddScoped<ICompanyRepository, CompanyRepository>();
            repository.AddScoped<ITrainingReviewRepository, TrainingReviewRepository>();
            repository.AddScoped<ITrainingRepository, TrainingRepository>();
            repository.AddScoped<ILecturerRepository, LecturerRepository>();
            repository.AddScoped<IAdminRepository, AdminRepository>();
            repository.AddScoped<IEventRepository, EventRepository>();
            repository.AddScoped<ICompanyRepository, CompanyRepository>();
            repository.AddScoped<IClassroomRepository, ClassroomRepository>();
            repository.AddScoped<IClientRepository, ClientRepository>();
            repository.AddScoped<IClientRepository, ClientRepository>();
            repository.AddScoped<ITopicRepository, TopicRepository>();
            repository.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterSwaggerAuth(this IServiceCollection swagger)
        {
            swagger.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
                });
            });
        }

        public static void RegisterAuthJwtToken(this IServiceCollection jwt)
        {
            jwt.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }
    }
}
