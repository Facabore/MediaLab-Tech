using MediaLab.Domain.Entities.Message;
using MediaLab.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MediaLab.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<Message> Messages { get; }
}