using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Constants;
using Birthday.Bot.Client.Handlers;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands.NamedContainers
{
    public class EndGameCommandContainer: BaseNamedMessageCommandContainer
    {
        public override string Name => CommandNames.EndGame;
        public override BaseMessageCommand GetCommand(Message message)
        {
            return new EndGameCommand(message);
        }
    }
}
