using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Birthday.Bot.Services.Models;
using Telegram.Bot.Types;

namespace Birthday.Bot.Client.Models
{
    public class Player: IIdentification
    {
        private readonly long _chatId;

        private Player(long chatId)
        {
            _chatId = chatId;
        }

        public string GetHash()
        {
            return _chatId.ToString();
        }

        public static explicit operator Player(Chat chat)
        {
            return new Player(chat.Id);
        }
    }
}
