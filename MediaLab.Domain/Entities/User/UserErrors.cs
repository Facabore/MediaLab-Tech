using MediaLab.Domain.Abstractions;

namespace MediaLab.Domain.Entities.User;

public static class UserErrors
{
    public static Error EmailAlreadyExist(string email) => new(
        "User.EmailAlreadyExist",
        $"The email '{email}' is already in use");
}