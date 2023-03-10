using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public Blink Blink;
    public bool TakeDamageFromPlayer;
    public bool TakeDamageFromAnyCollision;
   
    private void OnCollisionEnter(Collision other)
    {
       
        
        if (other.rigidbody)
        {
            if (other.rigidbody.GetComponent<Bullet>())
            TakeDamageOnColl();
            
            if (TakeDamageFromPlayer)
            if (other.rigidbody.GetComponent<PlayerHealth>())
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

