using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Transform Player;
    public EnemyHealth EnemyHealth;
    public AudioSource Blow;

    void Start()
    {
        Player=FindObjectOfType<PlayerHealth>().transform;
        Rigidbody.AddRelativeTorque(new Vector3(0,0,-500f));
        Vector3 Force=Player.position-transform.position;
       
        Rigidbody.AddForce(Force.normalized*500f);
        Destroy(gameObject,6f);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.rigidbody)
        //if (other.rigidbody.GetComponent<Bullet>() || other.rigidbody.GetComponent<PlayerMove>())
        {
            Blow.Play();//Не срабатывает так как самоуничтожается
            EnemyHealth.TakeDamage(1);
            
        }
    }

    
}
