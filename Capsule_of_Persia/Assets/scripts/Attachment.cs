using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    public GameObject Point;

    // Update is called once per frame
    void Update()
    {
        transform.position=Point.transform.position;
    }
}
