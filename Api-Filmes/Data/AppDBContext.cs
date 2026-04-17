namespace Api_Filmes.Data
{
    public class AppDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDBContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
