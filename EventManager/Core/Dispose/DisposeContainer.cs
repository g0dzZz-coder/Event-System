﻿namespace LP.EventManager.Events.Dispose.Container
{
    using System;
    
    public class DisposeContainer
    {
        private Action _disposeAction;

        public DisposeContainer(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }


        public void Invoke()
        {
            _disposeAction?.Invoke();
            _disposeAction = null;
        }
    }
}