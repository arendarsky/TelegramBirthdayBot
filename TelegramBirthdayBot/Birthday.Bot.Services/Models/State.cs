using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Services.Models
{
    public class State
    {
        public IStageChain StageChain { get; set; }
        public static State Default => new State();
    }
}
