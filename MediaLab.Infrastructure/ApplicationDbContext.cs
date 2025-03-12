using MediaLab.Application.Abstractions.Clock;
using MediaLab.Application.Abstractions.Data;
using MediaLab.Domain.Entities.Message;
using MediaLab.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MediaLab.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    private static readonly JsonSerializerSettings jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };

    private readonly IDateTimeProvider _dateTimeProvider;

    public DbSet<User> Users { get;  set; }
    public DbSet<Message> Messages { get;  set; }

    public ApplicationDbContext(
        DbContextOptions options,
        IDateTimeProvider dateTimeProvider)
        : base(options)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public ApplicationDbContext(
        DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangeAsync()
    {
        try
        {
            int result = await base.SaveChangesAsync();
            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw;
        }
    }
}