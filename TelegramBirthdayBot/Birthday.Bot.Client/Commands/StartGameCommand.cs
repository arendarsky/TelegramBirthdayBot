using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Constants;

namespace Birthday.Bot.Client.Commands
{
    public class StartGameCommand: BaseMessageCommand
    {
        public override string Name => CommandNames.StartGame;
    }
}
