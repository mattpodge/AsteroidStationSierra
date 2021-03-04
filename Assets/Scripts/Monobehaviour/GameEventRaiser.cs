﻿using UnityEngine;

public class GameEventRaiser : MonoBehaviour
{
    public GameEvent eventToRaise;

    public void RaiseEvent()
    {
        if (eventToRaise == null)
        {
            Debug.Log("Event was not set for Event Raiser on GameObject named:" + gameObject.name);
            return;
        }

        eventToRaise.Raise();
    }
}
