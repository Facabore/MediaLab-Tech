using MediaLab.Application.Abstractions.Clock;
using MediaLab.Application.Dtos;
using MediaLab.Domain.Abstractions;
using MediaLab.Domain.Entities.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaLab.Api.Controllers.Messages;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MessageController(IMessageRepository messageRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _messageRepository = messageRepository;
        _dateTimeProvider = dateTimeProvider;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllMessages()
    {
        var messages = await _messageRepository.GetAllMessages();

        return Ok(messages);
    }

    [HttpPost("/send")]
    public async Task<IActionResult> SendMessage(MessageDTO messageDto)
    {
        Result<Message> message = Message.Create(
            messageDto.Content,
            _dateTimeProvider.UtcNow);

        await _messageRepository.Add(message.Value);

        return Created();


    }
}
