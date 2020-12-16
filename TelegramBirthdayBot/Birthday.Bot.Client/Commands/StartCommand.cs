using Birthday.Bot.Client.Constants;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands
{
    public class StartCommand: BaseMessageCommand
    {
        public StartCommand(Message message) : base(message)
        {
        }
    }
}
