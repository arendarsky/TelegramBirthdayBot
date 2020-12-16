using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Client.Commands;
using Birthday.Bot.Client.Commands.NamedContainers;
using Birthday.Bot.Domain.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Birthday.Bot.Client.Factories
{
    public class CommandFactory
    {
        private readonly PrizeFactory _prizeFactory;
        private readonly IEnumerable<BaseNamedMessageCommandContainer> _namedMessageCommandContainers;

        public CommandFactory(PrizeFactory prizeFactory)
        {
            _prizeFactory = prizeFactory;
            _namedMessageCommandContainers = new BaseNamedMessageCommandContainer[]
                {new StartCommandContainer(), new StartGameCommandContainer(), new EndGameCommandContainer()};
        }

        public BaseMessageCommand MakeMessageCommand(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Audio:
                    return new PrizeInputCommand(message, _prizeFactory.MakePrize(message, PrizeTypes.Audio));
                case MessageType.Video:
                    return new PrizeInputCommand(message, _prizeFactory.MakePrize(message, PrizeTypes.Video));
                case MessageType.Sticker:
                    return new PrizeInputCommand(message, _prizeFactory.MakePrize(message, PrizeTypes.Sticker));
                case MessageType.Text:
                    var namedContainer = GetNamedMessageCommandContainer(message);
                    return namedContainer == null ? new UserInputCommand(message) : namedContainer.GetCommand(message);
                default:
                    return null;
            }
        }

        private BaseNamedMessageCommandContainer GetNamedMessageCommandContainer(Message message)
        {
            return _namedMessageCommandContainers.FirstOrDefault(container =>
                string.Equals(container.Name, message.Text, StringComparison.Ordinal));
        }
    }
}
