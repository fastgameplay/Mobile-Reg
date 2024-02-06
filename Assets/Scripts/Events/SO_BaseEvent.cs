namespace ScriptableEvents
{
    using UnityEngine;
    using System;

    public abstract class SO_BaseEvent : ScriptableObject
    {
        public Action Event {
            get{ return eventHandler;}
            set{ eventHandler = value;}
        }

        protected Action eventHandler;

        public void AddListener(Action listener){
            Event += listener;
        }

        public void RemoveListener(Action listener){
            Event -= listener;
        }

        public static SO_BaseEvent operator +(SO_BaseEvent baseEvent, Action listener){
            baseEvent.AddListener(listener);
            return baseEvent;
        }

        public static SO_BaseEvent operator -(SO_BaseEvent baseEvent, Action listener){
            baseEvent.RemoveListener(listener);
            return baseEvent;
        }

        public void Invoke(){
            Event?.Invoke();
        }
    }
    
    public abstract class SO_BaseEvent<T> : ScriptableObject
    {
        public Action<T> Event {
            get{ return eventHandler;}
            set{ eventHandler = value;}
        }

        private Action<T> eventHandler;

        public void AddListener(Action<T> listener){
            Event += listener;
        }

        public void RemoveListener(Action<T> listener){
            Event -= listener;
        }
        
        public static SO_BaseEvent<T> operator +(SO_BaseEvent<T> baseEvent, Action<T> listener){
            baseEvent.AddListener(listener);
            return baseEvent;
        }

        public static SO_BaseEvent<T> operator -(SO_BaseEvent<T> baseEvent, Action<T> listener){
            baseEvent.RemoveListener(listener);
            return baseEvent;
        }

        public void Invoke(T value){
            eventHandler?.Invoke(value);
        }
    }
    public abstract class SO_BaseEvent<T,J> : ScriptableObject
    {
        public Action<T, J> Event {
            get{ return eventHandler;}
            set{ eventHandler = value;}
        }

        private Action<T, J> eventHandler;

        public void AddListener(Action<T, J> listener){
            Event += listener;
        }

        public void RemoveListener(Action<T, J> listener){
            Event -= listener;
        }

        public static SO_BaseEvent<T, J> operator +(SO_BaseEvent<T, J> baseEvent, Action<T, J> listener){
            baseEvent.AddListener(listener);
            return baseEvent;
        }

        public static SO_BaseEvent<T, J> operator -(SO_BaseEvent<T, J> baseEvent, Action<T, J> listener){
            baseEvent.RemoveListener(listener);
            return baseEvent;
        }

        public void Invoke(T arg1, J arg2){
            eventHandler?.Invoke(arg1,arg2);
        }
    }
}