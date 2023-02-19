using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonApi.Data.Models;
using PersonApi.Helpers.SampleData;

namespace PersonApi.Data;

public class LorenzContext : DbContext
{
    public DbSet<Person> People { get; set; }

    public LorenzContext(DbContextOptions<LorenzContext> options)
        : base(options)
    {
        // this is nesseccary for InMemory only. use migrations with permanent db
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("LorenzDb")
            .EnableSensitiveDataLogging(true)
            .ConfigureWarnings(w =>
            {
                w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
            })
            .LogTo(Console.WriteLine, LogLevel.Information);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasData(new PersonFaker().Generate(5));
            
        base.OnModelCreating(modelBuilder);
    }
}
