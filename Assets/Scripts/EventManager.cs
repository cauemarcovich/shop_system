using System;
using System.Collections.Generic;
using Events;

public static class EventManager
{
    private static readonly Dictionary<GameEvents, Action> _events = new();
    private static readonly Dictionary<GameEvents, Action<object>> _eventsParam = new();
    
    public static void StartListening(GameEvents eventName, Action<object> listener)
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

    public static void StartListening(GameEvents eventName, Action listener)
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

    public static void StopListening(GameEvents eventName, Action<object> listener)
    {
        if (_eventsParam.TryGetValue(eventName, out Action<object> @event))
        {
            @event -= listener;
            _eventsParam[eventName] = @event;
        }
    }

    public static void StopListening(GameEvents eventName, Action listener)
    {
        if (_events.TryGetValue(eventName, out Action @event))
        {
            @event -= listener;
            _events[eventName] = @event;
        }
    }

    public static void TriggerEvent(GameEvents eventName, object eventParam)
    {
        if (_eventsParam.TryGetValue(eventName, out Action<object> @event))
        {
            if (@event != null)
            {
                @event.Invoke(eventParam);
            }
        }
    }

    public static void TriggerEvent(GameEvents eventName)
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