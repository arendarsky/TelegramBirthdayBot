using MediatR;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public abstract class BaseMessageCommand: IRequest<bool>
    {
        public abstract string Name { get; }
        public Message Message { get; set; }
    }
}
