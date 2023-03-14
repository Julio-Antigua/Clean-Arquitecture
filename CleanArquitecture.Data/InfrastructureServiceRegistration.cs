
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Models;
using CleanArquitecture.Infrastructure.Email;
using CleanArquitecture.Infrastructure.Persistence;
using CleanArquitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArquitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StreamerDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>),typeof(RepositoryBase<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService,EmailService>();

            return services;
        }
    }
}
