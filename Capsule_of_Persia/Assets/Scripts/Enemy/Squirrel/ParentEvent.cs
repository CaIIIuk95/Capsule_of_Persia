using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentEvent : MonoBehaviour
{
    public UnityEvent Event0;
    public UnityEvent Event1;

    public void StartEvent()
    {
        Event0.Invoke();
    }

    public void Scream()
    {
        Event1.Invoke();
    }
}
