using MediatR;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public abstract class BaseMessageCommand: IRequest
    {
        protected BaseMessageCommand(Message message)
        {
            Message = message;
        }
        public Message Message { get; }
    }
}
