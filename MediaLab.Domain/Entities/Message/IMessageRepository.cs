namespace MediaLab.Domain.Entities.Message;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetAllMessages();
    Task Add(Message  message);
}