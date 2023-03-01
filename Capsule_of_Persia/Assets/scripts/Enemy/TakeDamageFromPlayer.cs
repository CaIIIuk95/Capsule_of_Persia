using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromPlayer : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        EnemyHealth.TakeDamage(1);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        EnemyHealth.TakeDamage(1);
    }
}
