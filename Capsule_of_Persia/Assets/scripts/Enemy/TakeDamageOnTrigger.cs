using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public Blink Blink;
    public bool TakeDamageFromPlayer;
    public bool TakeDamageFromAnyCollision;
   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            TakeDamageOnColl();
            if (TakeDamageFromPlayer)
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            TakeDamageOnColl();
            
        }
        if (TakeDamageFromAnyCollision)
            TakeDamageOnColl();
    }

    private void TakeDamageOnColl()
    {
        
        EnemyHealth.TakeDamage(1);
        if (Blink!=null)
        Blink.StartBlink();
    }
} 
