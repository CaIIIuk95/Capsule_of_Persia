using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 1;
    public float ActivateDistance = 20f;

    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, ActivateDistance);
    }
#endif
}
