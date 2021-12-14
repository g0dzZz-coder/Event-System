﻿using System;
using System.Collections.Generic;
using Depra.EventSystem.Runtime.Core.Events.Base;

namespace Depra.EventSystem.Runtime.Core.Events.Static
{
    public class ObjectArgsEvent : EventBase
    {
        private readonly Dictionary<string, List<Action<object[]>>> _actions = new Dictionary<string, List<Action<object[]>>>();
        
        public void Add(string key, Action<object[]> action)
        {
            if (_actions.ContainsKey(key) == false)
            {
                _actions.Add(key, new List<Action<object[]>>());
            }
            
            _actions[key].Add(action);
        }

        public void Remove(string key, Action<object[]> action)
        {
            if (_actions.TryGetValue(key, out var val))
            {
                val.Remove(action);
            }
        }
        
        public void Invoke(string key, params object[] parameters)
        {
            if (_actions.TryGetValue(key, out var actions) == false)
            {
                return;
            }

            foreach (var action in actions)
            {
                action?.Invoke(parameters);
            }
        }
    }
}