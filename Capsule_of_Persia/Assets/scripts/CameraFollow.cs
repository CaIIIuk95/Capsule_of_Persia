using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float LerpRate;

    void Update()
    {
        transform.position=Vector3.Lerp(transform.position,target.transform.position,Time.deltaTime * LerpRate);
    }
}
