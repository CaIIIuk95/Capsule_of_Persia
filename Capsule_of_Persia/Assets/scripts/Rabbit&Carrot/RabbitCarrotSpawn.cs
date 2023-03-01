using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitCarrotSpawn : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Spawn;
    private Transform Player;
    private Vector3 rotA=new Vector3(-90,90,-15f);
    private Vector3 rotB=new Vector3(-90,90,-165f);
    private Vector3 _targetEuler;

  
    private void Start()
    {
        Player=FindObjectOfType<PlayerHealth>().transform;
    }
    public void CarrotSpawn()
    {
        Spawn.position=new Vector3(Spawn.position.x,Spawn.position.y,0f);
        Instantiate(Prefab,Spawn.position,Quaternion.identity);
    }

    public void Update()
    {
        if (Player.position.x<transform.position.x)
        {
           _targetEuler=rotA; 
        }
        else
        {
            _targetEuler=rotB;
        }

        transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(_targetEuler),Time.deltaTime * 5f);
    }
}
