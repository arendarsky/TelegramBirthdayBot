using Newtonsoft.Json;

namespace Birthday.Bot.Client.Commands
{
    public class CallbackData
    {
        public CallbackData()
        {

        }

        public CallbackData(string name, int? itemId = null)
        {
            Name = name;
            ItemId = itemId;
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("item_id")] public int? ItemId { get; set; }
    }
}
