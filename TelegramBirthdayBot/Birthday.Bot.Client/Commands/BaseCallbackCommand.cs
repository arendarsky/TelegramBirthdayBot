using MediatR;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public abstract class BaseCallbackCommand : IRequest<bool>
    {
        public abstract string Name { get; }
        public CallbackQuery CallbackQuery { get; set; }
        public CallbackData CallbackData { get; set; }
    }
}
