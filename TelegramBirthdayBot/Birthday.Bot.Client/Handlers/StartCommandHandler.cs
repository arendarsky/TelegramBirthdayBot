using System.Threading;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Constants;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Birthday.Bot.Client.Handlers
{
    public class StartCommandHandler: BaseCommandHandler<StartCommand>
    {
        private const string MessageText = MessageTexts.Welcome;
        private readonly ReplyKeyboardMarkup _keyboard = ReplyKeyBoards.MainMenu;

        public StartCommandHandler(ITelegramBotClient telegramBotClient): base(telegramBotClient)
        {

        }

        public override async Task<Unit> Handle(StartCommand request, CancellationToken cancellationToken)
        {
            var message = request.Message;

            var chat = message?.Chat;

            await SendReply(chat);

            return Unit.Value;
        }

        #region Private Methods

        private async Task SendReply(Chat chat)
        {
            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageText, replyMarkup: _keyboard);
        }

        #endregion
    }
}
