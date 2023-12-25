using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Application.Abstractions.Services;
using PestKitOnionAB104.Persistence.Contexts;
using PestKitOnionAB104.Persistence.Implementations.Repositories;
using PestKitOnionAB104.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestKitOnionAB104.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ITagService, TagService>();

            return services;
        }
    }
}
