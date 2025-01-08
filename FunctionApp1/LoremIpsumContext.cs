using Microsoft.EntityFrameworkCore;

namespace FunctionApp1
{
    public class LoremIpsumContext : DbContext
    {
        public DbSet<LoremIpsum> LoremIpsums { get; set; }

        //public LoremIpsumContext() : base(@"Server=tcp:lancelot.database.windows.net,1433;Initial Catalog=Portfolio;Persist Security Info=False;User ID=lancelot;Password=Spuppy0224!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseAzureSql( "Data Source=products.db");
            //optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer(@"Server=tcp:lancelot.database.windows.net,1433;Initial Catalog=Portfolio;Persist Security Info=False;User ID=lancelot;Password=Spuppy0224!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
