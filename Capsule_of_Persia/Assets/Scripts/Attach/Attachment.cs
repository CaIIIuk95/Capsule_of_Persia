using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] private GameObject point;

    private void Update()
    {
        transform.position = point.transform.position;
    }
}
