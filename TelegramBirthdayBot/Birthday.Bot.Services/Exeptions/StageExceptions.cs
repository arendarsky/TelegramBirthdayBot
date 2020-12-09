using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday.Bot.Services.Exeptions
{
    public class NotStartedException: Exception
    {
        public NotStartedException() : base("Сначала начни игру!")
        {

        }
    }
}
