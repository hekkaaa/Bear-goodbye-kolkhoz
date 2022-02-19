using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repo;
using BearGoodbyeKolkhozProject.Data.Repositories;

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
            services.AddScoped<IClientService, ClientService>();
        }
     
        public static void RegisterProjectRepository(this IServiceCollection repository)
        {
            repository.AddScoped<ITrainingRepository, TrainingRepository>();
            repository.AddScoped<ITrainingReviewRepository, TrainingReviewRepository>();
            repository.AddScoped<ITrainingRepository, TrainingRepository>();
            repository.AddScoped<ILecturerRepository, LecturerRepository>();
            repository.AddScoped<IAdminRepository, AdminRepository>();
            repository.AddScoped<IEventRepository, EventRepository>();
            repository.AddScoped<ICompanyRepository, CompanyRepository>();
            repository.AddScoped<IClientRepository, ClientRepository>();
            repository.AddScoped<IClientRepository, ClientRepository>();
            repository.AddScoped<IAuthService, AuthService>();
        }
    }
}
