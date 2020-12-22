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

        public async Task SendPrizes(long chatId, IEnumerable<Prize> prizes, CancellationToken cancellationToken = default)
        {
            foreach (var prize in prizes)
            {
                await SendPrize(chatId, prize, cancellationToken);
            }
        }

        private async Task SendPrize(long chatId, Prize prize, CancellationToken cancellationToken)
        {
            switch (prize.Type)
            {
                case PrizeTypes.Audio:
                    await _telegramBotClient.SendAudioAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return;
                case PrizeTypes.Sticker:
                    await _telegramBotClient.SendStickerAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return;
                case PrizeTypes.Video:
                    await _telegramBotClient.SendVideoAsync(chatId, prize.Hash, cancellationToken: cancellationToken);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
