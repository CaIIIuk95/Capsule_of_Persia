using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    void Update()
    {
       
        Destroy(gameObject,2f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(EffectPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (!other.gameObject.GetComponent<LootHeal>())
        {
            Instantiate(EffectPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
