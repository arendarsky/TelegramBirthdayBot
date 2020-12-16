using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Constants;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands.NamedContainers
{
    public class StartCommandContainer: BaseNamedMessageCommandContainer
    {
        public override string Name => CommandNames.Start;
        public override BaseMessageCommand GetCommand(Message message)
        {
            return new StartCommand(message);
        }
    }
}
