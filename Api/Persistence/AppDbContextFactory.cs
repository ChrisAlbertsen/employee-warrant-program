using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        var connectionString = "Server=tcp:employee-warrant-program-db-server.database.windows.net,1433;Initial Catalog=employee-warrant-program-db;Persist Security Info=False;User ID=employee-warrant-program-db-admin;Password=ThisIsMyPassword123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        optionsBuilder.UseSqlServer(connectionString,
            option => option.EnableRetryOnFailure());

        return new AppDbContext(optionsBuilder.Options);
    }
}