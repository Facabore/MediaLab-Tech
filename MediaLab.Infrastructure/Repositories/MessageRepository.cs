using MediaLab.Domain.Entities.Message;
using MediaLab.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MediaLab.Infrastructure.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Message>> GetAllMessages()
    {
        return await _context.Messages.ToListAsync();
    }

    public async Task Add(Message message)
    {
        await _context.AddAsync(message);
        await _context.SaveChangeAsync();
    }
}