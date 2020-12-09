using System;
using System.Collections.Generic;
using System.Text;
using Birthday.Bot.Services.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Birthday.Bot.Services.Services
{
    public interface IStateService
    {
        State GetState(IIdentification identification);
        void UpdateState(IIdentification identification, State state);
    }

    public class StateService: IStateService
    {
        private readonly IDictionary<string, State> _states;

        public StateService()
        {
            _states = new Dictionary<string, State>();
        }

        public State GetState(IIdentification identification)
        {
            var key = identification.GetHash();

            return _states.TryGetValue(key, out var state) ? state : null;
        }

        public void UpdateState(IIdentification identification, State state)
        {
            var key = identification.GetHash();
            _states[key] = state;
        }
    }
}
