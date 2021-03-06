﻿using System.Collections.Generic;

namespace Birthday.Bot.Domain.DataInterfaces.Assignment
{
    public interface IAssignmentData
    {
        string Description { get; set; }
        IEnumerable<string> CorrectAnswers { get; set; }
    }
}
