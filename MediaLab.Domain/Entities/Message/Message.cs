using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using MediaLab.Domain.Abstractions;

namespace MediaLab.Domain.Entities.Message;

public class Message : Entity
{
    private Message(
        Guid id,
        string content,
        DateTime createdOnUtc)
        : base(id)
    {
        Content = content;
        CreatedOnUtc = createdOnUtc;
    }

    private Message()
    {

    }

    public string Content { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Message Create(string content, DateTime createdOnUtc)
    {
        var message = new Message(Guid.NewGuid(), content, createdOnUtc);
        return message;
    }

}