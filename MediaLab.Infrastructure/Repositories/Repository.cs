using MediaLab.Domain.Abstractions;

namespace MediaLab.Infrastructure.Repositories;

public abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext _context;

    protected Repository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    public  virtual void Add(T entity)
    {
         _context.Add(entity);
         _context.SaveChangesAsync();
    }
}