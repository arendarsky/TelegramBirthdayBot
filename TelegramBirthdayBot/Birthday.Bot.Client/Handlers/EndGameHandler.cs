using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Constants;
using MediatR;
using Telegram.Bot;

namespace Birthday.Bot.Client.Handlers
{
    public class EndGameHandler: BaseCommandHandler<EndGameCommand>
    {
        public EndGameHandler(ITelegramBotClient telegramBotClient) : base(telegramBotClient)
        {
        }

        public override Task<Unit> Handle(EndGameCommand request, CancellationToken cancellationToken)
        {
            TelegramBotClient.SendTextMessageAsync(request.Message.Chat.Id, MessageTexts.PresentLocation,
                replyMarkup: ReplyKeyBoards.MainMenu, cancellationToken: cancellationToken);
            return Task.FromResult(Unit.Value);
        }
    }
}
