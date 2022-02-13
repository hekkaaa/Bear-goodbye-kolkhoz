using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.Interfaces;
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
      
        }

        public static void RegisterProjectRepository(this IServiceCollection repository)
        {
            repository.AddScoped<ITrainingRepository, TrainingRepository>();
            repository.AddScoped<ITrainingReviewRepository, TrainingReviewRepository>();
            repository.AddScoped<ITrainingRepository, TrainingRepository>();
            repository.AddScoped<ILecturerRepository, LecturerRepository>();
        }
    }
}
