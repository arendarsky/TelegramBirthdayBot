using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Telegram.Bot;

namespace Birthday.Bot.Client.Handlers
{
    public abstract class BaseCommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : IRequest<Unit>
    {
        protected readonly ITelegramBotClient TelegramBotClient;

        protected BaseCommandHandler(ITelegramBotClient telegramBotClient)
        {
            TelegramBotClient = telegramBotClient;
        }

        public abstract Task<Unit> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
