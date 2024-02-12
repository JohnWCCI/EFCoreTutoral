using Microsoft.EntityFrameworkCore;

namespace EFCoreTutoral.Context
{
    public partial class EfCoreContext : DbContext
    {
        private readonly IConfiguration configuration;
        public EfCoreContext(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(paramName: nameof(configuration), message: "IConfiguration is not defined");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Can Not find ConnectionString DefaultConnection");
            }
            optionsBuilder.UseSqlServer(connectionString);
        }
       
    }
}
