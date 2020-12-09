using System;

namespace Birthday.Bot.Services.Exeptions
{
    public class NotStartedException: Exception
    {
        public NotStartedException() : base("Сначала начни игру!")
        {

        }
    }
}
