using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Birthday.Bot.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITelegramBotService _telegramBotService;

        public AdminController(ITelegramBotService telegramBotService)
        {
            _telegramBotService = telegramBotService;
        }

        [Route("set_webhook")]
        [HttpGet]
        public async Task SetWebHook(string url = null)
        {
            await _telegramBotService.SetWebHookAsync(url);
        }
    }
}