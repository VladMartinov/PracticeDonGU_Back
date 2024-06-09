using Microsoft.EntityFrameworkCore;
using PracticeDonGU_Back.Contexts;

namespace PracticeDonGU_Back.Extensions
{
    public static class DbContextRegistrar
    {
        private const string ConnectionStringName = "Default";

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            services.AddDbContext<PracticeDbContext>(opts => opts.UseSqlServer(connectionString));

            return services;
        }
    }
}
