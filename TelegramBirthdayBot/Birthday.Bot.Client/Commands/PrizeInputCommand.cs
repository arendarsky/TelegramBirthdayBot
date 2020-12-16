using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Domain.Entities;
using Birthday.Bot.Domain.Enums;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public class PrizeInputCommand: BaseMessageCommand
    {
        public PrizeInputCommand(Message message, Prize prize) : base(message)
        {
            Prize = prize;
        }

        public Prize Prize { get; }
    }
}
