using Telegram.Bot.Types.ReplyMarkups;

namespace Birthday.Bot.Client.Constants
{
    public class ReplyKeyBoards
    {
        public static readonly ReplyKeyboardMarkup MainMenu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton
                {
                    Text = CommandNames.StartGame
                },
            }
        });

        public static readonly ReplyKeyboardMarkup End = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton
                {
                    Text = CommandNames.EndGame
                },
            }
        });
    }
}
