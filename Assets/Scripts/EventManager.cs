using System;
using System.Collections.Generic;

public static class EventManager
{
    private static readonly Dictionary<string, Action> _events = new();
    private static readonly Dictionary<string, Action<object>> _eventsParam = new();
    
    public static void StartListening(string eventName, Action<object> listener)
    {
        if (_eventsParam.TryGetValue(eventName, out Action<object> @event))
        {
            @event += listener;
            _eventsParam[eventName] = @event;
        }
        else
        {
            @event += listener;
            _eventsParam.Add(eventName, @event);
        }
    }

    public static void StartListening(string eventName, Action listener)
    {
        if (_events.TryGetValue(eventName, out Action @event))
        {
            @event += listener;
            _events[eventName] = @event;
        }
        else
        {
            @event += listener;
            _events.Add(eventName, @event);
        }
    }

    public static void StopListening(string eventName, Action<object> listener)
    {
        if (_eventsParam.TryGetValue(eventName, out Action<object> @event))
        {
            @event -= listener;
            _eventsParam[eventName] = @event;
        }
    }

    public static void StopListening(string eventName, Action listener)
    {
        if (_events.TryGetValue(eventName, out Action @event))
        {
            @event -= listener;
            _events[eventName] = @event;
        }
    }

    public static void TriggerEvent(string eventName, object eventParam)
    {
        if (_eventsParam.TryGetValue(eventName, out Action<object> @event))
        {
            if (@event != null)
            {
                @event.Invoke(eventParam);
            }
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (_events.TryGetValue(eventName, out Action @event))
        {
            if (@event != null)
            {
                @event.Invoke();
            }
        }
    }
}