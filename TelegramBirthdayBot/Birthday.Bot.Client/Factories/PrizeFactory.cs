using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Domain.Entities;
using Birthday.Bot.Domain.Enums;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Factories
{
    public class PrizeFactory
    {
        public Prize MakePrize(Message message, PrizeTypes type)
        {
            return type switch
            {
                PrizeTypes.Audio => new Prize {Type = type, Hash = message.Audio.FileId},
                PrizeTypes.Sticker => new Prize {Type = type, Hash = message.Sticker.FileId},
                PrizeTypes.Video => new Prize {Type = type, Hash = message.Video.FileId},
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}
