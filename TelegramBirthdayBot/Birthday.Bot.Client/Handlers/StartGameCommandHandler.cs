using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Constants;
using Birthday.Bot.Client.Models;
using Birthday.Bot.Services.Models;
using Birthday.Bot.Services.Services;
using MediatR;
using Telegram.Bot;

namespace Birthday.Bot.Client.Handlers
{
    public class StartGameCommandHandler: BaseCommandHandler<StartGameCommand>
    {
        private readonly IStateService _stateService;
        private readonly IStageChainService _stageChainService;

        public StartGameCommandHandler(ITelegramBotClient telegramBotClient, IStateService stateService, IStageChainService stageChainService) : base(telegramBotClient)
        {
            _stateService = stateService;
            _stageChainService = stageChainService;
        }

        public override async Task<Unit> Handle(StartGameCommand request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;
            var player = (Player)chat;
            var stageChain = _stageChainService.CreateNew();
            _stateService.UpdateState(player, new State(stageChain));
            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.BeforeFirstQuestion, cancellationToken: cancellationToken);
            var firstQuestion = stageChain.Stage.AssignmentDescription;
            await TelegramBotClient.SendTextMessageAsync(chat.Id, firstQuestion, cancellationToken: cancellationToken);
            return Unit.Value;
        }
    }
}
