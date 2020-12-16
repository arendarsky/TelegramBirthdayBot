using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Constants;
using Birthday.Bot.Client.Models;
using Birthday.Bot.Client.Settings;
using Birthday.Bot.Domain.Entities;
using Birthday.Bot.Domain.Enums;
using Birthday.Bot.Services.Services;
using MediatR;
using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace Birthday.Bot.Client.Handlers
{
    public class PrizeInputCommandHandler: BaseCommandHandler<PrizeInputCommand>
    {
        private readonly TelegramBotSettings _settings;
        private readonly IStateService _stateService;
        private readonly IPrizeService _prizeService;

        public PrizeInputCommandHandler(ITelegramBotClient telegramBotClient, IOptions<TelegramBotSettings> settingsOptions, IStateService stateService, IPrizeService prizeService) : base(telegramBotClient)
        {
            _settings = settingsOptions.Value;
            _stateService = stateService;
            _prizeService = prizeService;
        }

        public override async Task<Unit> Handle(PrizeInputCommand request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;

            if (chat.Id != _settings.AdminChatId)
            {
                return Unit.Value;
            }

            var player = (Player)chat;
            var state = _stateService.GetState(player);

            if (state?.StageChain == null)
            {
                return Unit.Value;
            }

            _prizeService.SetPrize(state.StageChain.Stage.Order, request.Prize);
            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.PrizeIsSet,
                cancellationToken: cancellationToken);

            return Unit.Value;
        }
    }
}
