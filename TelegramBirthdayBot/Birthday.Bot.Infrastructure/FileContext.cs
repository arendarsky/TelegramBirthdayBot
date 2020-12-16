using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Infrastructure.DataModels;
using Newtonsoft.Json;

namespace Birthday.Bot.Infrastructure
{
    public class FileContext: IDataContext
    {
        private readonly string _filePath = "stages.json";

        public FileContext()
        {
            var jsonString = File.ReadAllText(_filePath);
            Stages = JsonConvert.DeserializeObject<IEnumerable<StageData>>(jsonString);
        }

        public IEnumerable<IStageData> Stages { get; }
        public void SaveChanges()
        {
            var jsonString = JsonConvert.SerializeObject(Stages);
            File.WriteAllText(_filePath, jsonString);
        }
    }
}
