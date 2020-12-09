using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Domain.Entities.Stage;
using Birthday.Bot.Services.Models;

namespace Birthday.Bot.Services.Services
{
    public interface IStageChainService
    {
        IStageChain GetChain(IIdentification identification);
    }

    public class StageChainService: IStageChainService
    {
        public IStageChain GetChain(IIdentification identification)
        {
            throw new NotImplementedException();
        }
    }
}
