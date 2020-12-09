using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Telegram.Bot;

namespace Birthday.Bot.Client.Handlers
{
    public abstract class BaseCommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, TResponse> where TCommand: IRequest<TResponse>
    {
        protected readonly ITelegramBotClient TelegramBotClient;

        protected BaseCommandHandler(ITelegramBotClient telegramBotClient)
        {
            TelegramBotClient = telegramBotClient;
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
