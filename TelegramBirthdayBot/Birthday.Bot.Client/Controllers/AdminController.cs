using System.Text.Json;
using System.Threading.Tasks;
using Birthday.Bot.Client.Services;
using Birthday.Bot.Infrastructure;
using Birthday.Bot.Services.Interfaces;
using Birthday.Bot.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Birthday.Bot.Client.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITelegramBotService _telegramBotService;
        private readonly IPrizeService _prizeService;

        public AdminController(ITelegramBotService telegramBotService, IPrizeService prizeService)
        {
            _telegramBotService = telegramBotService;
            _prizeService = prizeService;
        }

        [Route("set_webhook")]
        [HttpGet]
        public async Task SetWebHook(string url = null)
        {
            await _telegramBotService.SetWebHookAsync(url);
        }

        [Route("clear_prizes")]
        [HttpGet]
        public void ClearPrizes()
        {
            _prizeService.ClearPrizes();
        }
    }
}