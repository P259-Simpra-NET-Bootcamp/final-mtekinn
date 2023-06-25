using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpraFinal.Data.Context.Factory;

public class SimpraFinalDbContextFactory : IDesignTimeDbContextFactory<SimpraFinalDbContext>
{
    public SimpraFinalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SimpraFinalDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost; Database=SimpraFinal; User=SA; Password=reallyStrongPwd123; MultipleActiveResultSets=true");

        return new SimpraFinalDbContext(optionsBuilder.Options);
    }
}