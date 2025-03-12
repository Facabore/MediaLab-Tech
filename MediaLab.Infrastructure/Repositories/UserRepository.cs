using MediaLab.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MediaLab.Infrastructure.Repositories;

public sealed class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<User?> GetEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task Add(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangeAsync();
    }
}