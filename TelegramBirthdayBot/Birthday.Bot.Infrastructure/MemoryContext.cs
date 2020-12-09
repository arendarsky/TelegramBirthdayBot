using System.Collections.Generic;
using Birthday.Bot.Domain.DataInterfaces.Assignment;
using Birthday.Bot.Domain.DataInterfaces.Stage;
using Birthday.Bot.Infrastructure.DataModels;

namespace Birthday.Bot.Infrastructure
{
    public class MemoryContext
    {
        public MemoryContext()
        {
            Stages = new[]
            {
                CreateStageData(1, CreateAssignmentData("Вспомни день, когда история задокументировала тебя, держащую во рту сигарету. Что за вкус был у сигареты?", "Говорят: \"...(ягода) на торте\"", "вишневый", "вишневая", "вишня", "вишенка")),
                CreateStageData(2, CreateAssignmentData("Какую передачу ты хотела бы посмотреть на удвоенной скорости воспроизведения?", "Ну ДАВАЙ, ПОдумай, ну ЖЕ...", "давай поженимся", "давай по-женимся")),
                CreateStageData(3, CreateAssignmentData("Мы начали своё общение в день вышки 2018 и кураторы дали нам особый квест, который мы выполняли вместе. Как он назывался?", "Дорога полушкольника", "путь первака", "путь первокурсника")),
                CreateStageData(4, CreateAssignmentData("Зачем ты покупала красивое белье и очки-кошечки в один день?", "Что ты делаешь другим на пленку?", "фотосессия", "для фотосессии")),
                CreateStageData(5, CreateAssignmentData("Что я пролила у Вас дома, когда мы первый раз общались вдвоём и ты помогала мне с smm?", "Так бухают малыши", "детское шампанское")),
                CreateStageData(6, CreateAssignmentData("Помнишь, как я в 2019 году решила похудеть? Ну и кто же был моим главным фитнес-советчиком? Конечно, ты! Помнишь эти долгие дискуссии по поводу умных весов... ? А как я тебе кидала свои пп завтраки?) Именно в то время ты мне порекомендовала одного фитнес блоггера, на которого я, кстати, подписана и до сих пор!Вспоминай, кто же это был...?!", "Начинается на fi (можешь посмотреть в подписчиках)", "@fitocaps", "fitocaps")),
                CreateStageData(7, CreateAssignmentData("Мы с тобой давно знакомы. Раньше во время прогулок мы много фотографировались. Сейчас мы уже не такие активные пользователи соц. сетей,  поэтому всё больше посвящаем наши встречи разговорам о жизни, любви и дружбе. Недавно я была у тебя дома. Как назывался фильм, который мы смотрели?", "Что-то типа \"Большие мужчины\"", "маленькие женщины", "little women"))
            };
        }

        public IEnumerable<IStageData> Stages { get; }

        public static StageData CreateStageData(int order, IAssignmentData assignment)
        {
            return new StageData
            {
                Order = order,
                Assignment = assignment
            };
        }

        public static AssignmentData CreateAssignmentData(string description, string suggestion,
            params string[] correctAnswers)
        {
            return new AssignmentData
            {
                Description = description,
                Suggestion = suggestion,
                CorrectAnswers = correctAnswers
            };
        }
    }
}
