using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Transform Player;
    private Rigidbody Rigidbody;
    public float Speed;
    public float TimeToRichSpeed=1f;

    private void Start()
    {
        Player=FindObjectOfType<PlayerHealth>().transform;
        Rigidbody=gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 point=(Player.position-transform.position).normalized;
        Vector3 Force=Rigidbody.mass * (point*Speed-Rigidbody.velocity)/TimeToRichSpeed;
        Rigidbody.AddForce(Force);
    }
}
