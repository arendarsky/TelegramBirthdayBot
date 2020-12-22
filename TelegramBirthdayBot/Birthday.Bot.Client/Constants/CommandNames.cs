namespace Birthday.Bot.Client.Constants
{
    public class CommandNames
    {
        #region Message Commands

        public const string Start = "/start";
        public const string StartGame = "Хочу начать День рождения!🥳";
        public const string EndGame = "А подарок?";

        #endregion

        #region Callback Commands

        public const string GoalDetail = "GoalDetail";
        public const string StartEditName = "StartEditName";
        public const string StartEditDescription = "StartEditDescription";
        public const string Subscribe = "Subscribe";
        public const string Unsubscribe = "Unsubscribe";
        public const string RemoveGoal = "RemoveGoal";

        #endregion

    }
}