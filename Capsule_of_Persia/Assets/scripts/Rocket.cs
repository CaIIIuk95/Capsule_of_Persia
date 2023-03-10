using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform _player;
    private Rigidbody Rigidbody;
    public float Speed,RotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _player=GameObject.FindObjectOfType<PlayerHealth>().transform;
        Rigidbody=gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=Time.deltaTime * transform.forward * Speed;
        Vector3 toPlayer = _player.position - transform.position;
        transform.position=new Vector3(transform.position.x,transform.position.y,0f);
        Quaternion targetRotation=Quaternion.LookRotation(toPlayer,Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime * RotationSpeed);
    }

    
}
