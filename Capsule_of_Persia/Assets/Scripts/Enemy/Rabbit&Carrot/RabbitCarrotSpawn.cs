using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCarrotSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawn;
    private Transform Player;
    private Vector3 rotA = new Vector3(-90, 90, -15f);
    private Vector3 rotB = new Vector3(-90, 90, -165f);
    private Vector3 _targetEuler;


    private void Start()
    {
        Player = FindObjectOfType<PlayerHealth>().transform;
    }
    public void CarrotSpawn()
    {
        spawn.position = new Vector3(spawn.position.x, spawn.position.y, 0f);
        Instantiate(prefab, spawn.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Player.position.x < transform.position.x)
        {
            _targetEuler = rotA;
        }
        else
        {
            _targetEuler = rotB;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * 5f);
    }
}
