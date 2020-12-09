using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Settings;
using MediatR;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client
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
        private readonly IEnumerable<BaseMessageCommand> _messageCommands;
        private readonly IEnumerable<BaseCallbackCommand> _callbackCommands;

        public TelegramBotService(ITelegramBotClient telegramBotClient, IMediator mediator)
        {
            _telegramBotClient = telegramBotClient;
            _mediator = mediator;
            _messageCommands = new List<BaseMessageCommand>
            {
                new StartCommand(), new StartGameCommand()
            };
            _callbackCommands = new List<BaseCallbackCommand>
            {
                
            };
        }

        public async Task SetWebHookAsync(string url)
        {
            var hook = CreateWebHook(url);

            await _telegramBotClient.SetWebhookAsync(hook);
        }

        public async Task HandleMessageAsync(Message message)
        {
            var command = GetMessageCommand(message.Text);

            if (command == null)
            {
                command = new UserInputCommand
                {
                    Message = message
                };
                await _mediator.Send(command);
                return;
            }

            command.Message = message;

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

        private BaseMessageCommand GetMessageCommand(string name)
        {
            return _messageCommands.FirstOrDefault(c => c.Name == name);
        }

        private static CallbackData GetCallbackData(string data)
        {
            return JsonConvert.DeserializeObject<CallbackData>(data);
        }

        private BaseCallbackCommand GetCallbackCommand(CallbackData data)
        {
            return _callbackCommands.FirstOrDefault(c => c.Name == data.Name);
        }

        #endregion
    }
}
