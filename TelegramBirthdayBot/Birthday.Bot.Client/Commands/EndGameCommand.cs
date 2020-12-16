using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Handlers
{
    public class EndGameCommand: BaseMessageCommand
    {
        public EndGameCommand(Message message) : base(message)
        {
        }
    }
}
