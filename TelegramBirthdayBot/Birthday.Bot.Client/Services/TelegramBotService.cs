using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Factories;
using Birthday.Bot.Client.Settings;
using MediatR;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Services
{
    public interface ITelegramBotService
    {
        Task SetWebHookAsync(string url);
        Task HandleMessageAsync(Message message);
        Task HandleCallbackQueryAsync(CallbackQuery callbackQuery);
    }

    public class TelegramBotService : ITelegramBotService
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IMediator _mediator;
        private readonly CommandFactory _commandFactory;

        public TelegramBotService(ITelegramBotClient telegramBotClient, IMediator mediator, CommandFactory commandFactory)
        {
            _telegramBotClient = telegramBotClient;
            _mediator = mediator;
            _commandFactory = commandFactory;
        }

        public async Task SetWebHookAsync(string url)
        {
            var hook = CreateWebHook(url);

            await _telegramBotClient.SetWebhookAsync(hook);
        }

        public async Task HandleMessageAsync(Message message)
        {
            var command = _commandFactory.MakeMessageCommand(message);

            if (command == null)
            {
                return;
            }

            await _mediator.Send(command);
        }

        public async Task HandleCallbackQueryAsync(CallbackQuery callbackQuery)
        {
            var callbackData = GetCallbackData(callbackQuery.Data);
            if (callbackData == null) return;

            var command = GetCallbackCommand(callbackData);
            if (command == null) return;
            command.CallbackQuery = callbackQuery;
            command.CallbackData = callbackData;

            await _mediator.Send(command);
        }

        #region Private Methods

        private string CreateWebHook(string url = null)
        {
            url = string.IsNullOrWhiteSpace(url) ? AppHttpContext.AppBaseUrl : url;
            return $"{ url}/messageksdhnd21sd/updatekjjwnjji1213dk";
        }

        private static CallbackData GetCallbackData(string data)
        {
            return JsonConvert.DeserializeObject<CallbackData>(data);
        }

        private BaseCallbackCommand GetCallbackCommand(CallbackData data)
        {
            return null;
        }

        #endregion
    }
}
