using System.ComponentModel.DataAnnotations;
using MediaLab.Domain.Abstractions;

namespace MediaLab.Domain.Entities.User;

public sealed class User : Entity
{
    private User(
        Guid id,
        string fullName,
        string email)
        : base(id)
    {
        FullName = fullName;
        Email = email;
    }

    private User()
    {

    }

    public string FullName { get; private set; }

    public string Email { get; private set; }

    public static User Create(string fullName, string email)
    {
        var user = new User(Guid.NewGuid(), fullName, email);

        return user;
    }

}