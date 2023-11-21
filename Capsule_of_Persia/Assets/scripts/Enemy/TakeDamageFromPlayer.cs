using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromPlayer : MonoBehaviour
{
    [SerializeField] private EnemyHealth EnemyHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
            EnemyHealth.TakeDamage(1);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
            EnemyHealth.TakeDamage(1);
    }
}
