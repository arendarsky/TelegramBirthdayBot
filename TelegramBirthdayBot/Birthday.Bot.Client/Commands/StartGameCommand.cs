using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Constants;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public class StartGameCommand: BaseMessageCommand
    {
        public StartGameCommand(Message message) : base(message)
        {
        }
    }
}
