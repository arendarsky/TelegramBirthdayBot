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
    public class UserInputCommandHandler: BaseCommandHandler<UserInputCommand, bool>
    {
        private readonly IStateService _stateService;
        private readonly IMediator _mediator;

        public UserInputCommandHandler(ITelegramBotClient telegramBotClient, IStateService stateService, IMediator mediator) : base(telegramBotClient)
        {
            _stateService = stateService;
            _mediator = mediator;
        }

        public async override Task<bool> Handle(UserInputCommand request, CancellationToken cancellationToken)
        {
            var chat = request.Message.Chat;
            var player = (Player) chat;
            var state = _stateService.GetState(player);

            if (state?.StageChain == null)
            {
                await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.NotStarted, cancellationToken: cancellationToken);
                return true;
            }

            var stage = state.StageChain.Stage;
            stage.Complete(request.Message.Text);

            if (!stage.IsSuccessful)
            {
                await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.WrongAnswer, cancellationToken: cancellationToken);
                await TelegramBotClient.SendTextMessageAsync(chat.Id, stage.Suggestion, cancellationToken: cancellationToken);
                return true;
            }

            await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.CorrectAnswer, cancellationToken: cancellationToken);
            var stageChain = state.StageChain.Next;

            if (stageChain == null)
            {
                await TelegramBotClient.SendTextMessageAsync(chat.Id, MessageTexts.EndGame, replyMarkup: ReplyKeyBoards.End, cancellationToken: cancellationToken);
                _stateService.UpdateState(player, State.Default);
                return true;
            }

            _stateService.UpdateState(player, new State(stageChain));
            await TelegramBotClient.SendTextMessageAsync(chat.Id, stageChain.Stage.AssignmentDescription, cancellationToken: cancellationToken);
            return true;
        }
    }
}
