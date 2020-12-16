using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.Enums;

namespace Birthday.Bot.Domain.Entities
{
    public class Prize
    {
        public string Hash { get; set; }
        public PrizeTypes Type { get; set; }
    }
}
