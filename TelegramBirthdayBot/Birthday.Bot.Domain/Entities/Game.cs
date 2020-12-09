using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Birthday.Bot.Domain.Entities.Stage;

namespace Birthday.Bot.Domain.Entities
{
    public interface IGame
    {
        IStage Stage { get; set; }
        void CompleteStage
    }

    public class Game
    {
    }
}
