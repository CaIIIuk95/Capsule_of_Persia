using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody ownRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float timeToRichSpeed = 1f;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        ownRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 point = (player.position - transform.position).normalized;
        Vector3 Force = ownRigidbody.mass * (point * speed - ownRigidbody.velocity) / timeToRichSpeed;
        ownRigidbody.AddForce(Force);
    }
}
