using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Extension
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<BlogContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BlogDb")));
            return services;
        }
    }
}
