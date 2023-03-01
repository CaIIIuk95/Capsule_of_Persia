using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour
{
    public float TimeToDie=5f;
    void Start()
    {
        
        Destroy(gameObject,TimeToDie);
    }
}
