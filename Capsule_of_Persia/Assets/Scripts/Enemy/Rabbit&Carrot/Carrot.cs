using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody ownRigidbody;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private AudioSource blow;

    private Transform Player;

    private void Start()
    {
        Player = FindObjectOfType<PlayerHealth>().transform;
        ownRigidbody.AddRelativeTorque(new Vector3(0, 0, -500f));
        Vector3 Force = Player.position - transform.position;

        ownRigidbody.AddForce(Force.normalized * 500f);
        Destroy(gameObject, 6f);
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.rigidbody)
        //if (other.rigidbody.GetComponent<Bullet>() || other.rigidbody.GetComponent<PlayerMove>())
        {
            blow.Play();//Не срабатывает так как самоуничтожается
            enemyHealth.TakeDamage(1);

        }
    }


}
