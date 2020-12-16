using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Commands.NamedContainers
{
    public abstract class BaseNamedMessageCommandContainer
    {
        public abstract string Name { get; }
        public abstract BaseMessageCommand GetCommand(Message message);
    }
}
