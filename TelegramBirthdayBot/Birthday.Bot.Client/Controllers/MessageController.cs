using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Birthday.Bot.Client.Controllers
{
    [ApiController]
    [Route("[controller]ksdhnd21sd")]
    public class MessageController : ControllerBase
    {
        private readonly ITelegramBotService _telegramBotService;

        public MessageController(ITelegramBotService telegramBotService)
        {
            _telegramBotService = telegramBotService;
        }

        [Route("updatekjjwnjji1213dk")]
        [HttpPost]
        public async Task Update([FromBody]Update update)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    await _telegramBotService.HandleMessageAsync(update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    await _telegramBotService.HandleCallbackQueryAsync(update.CallbackQuery);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
