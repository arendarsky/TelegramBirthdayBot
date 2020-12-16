using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Birthday.Bot.Domain.Entities;
using Birthday.Bot.Domain.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Services
{
    public interface IPrizeSendingService
    {
        Task SendPrizes(long chatId, IEnumerable<Prize> prizes, CancellationToken cancellationToken = default);
    }

    public class PrizeSendingService: IPrizeSendingService
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public PrizeSendingService(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public Task SendPrizes(long chatId, IEnumerable<Prize> prizes, CancellationToken cancellationToken = default)
        {
            foreach (var prize in prizes)
            {
                SendPrize(chatId, prize, cancellationToken);
            }

            return Task.CompletedTask;
        }

        private Task SendPrize(long chatId, Prize prize, CancellationToken cancellationToken)
        {
            switch (prize.Type)
            {
                case PrizeTypes.Audio:
                    _telegramBotClient.SendAudioAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return Task.CompletedTask;
                case PrizeTypes.Sticker:
                    _telegramBotClient.SendStickerAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return Task.CompletedTask;
                case PrizeTypes.Video:
                    _telegramBotClient.SendVideoAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return Task.CompletedTask;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
