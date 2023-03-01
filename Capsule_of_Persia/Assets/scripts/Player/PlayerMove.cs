using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float JumpSpeed,MoveSpeed,Friction;
    private Rigidbody Rgbody;
    public bool Grounded;
    public Transform ColliderTransform;
    public float MaxSpeed;
    private int _jumpFrameCounter;
    
    private void Start()
    {
        Rgbody=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !Grounded )
        {
            ColliderTransform.localScale=Vector3.Lerp(ColliderTransform.localScale,new Vector3(1f,0.5f,1f),Time.deltaTime*15f);
        }
        else
        {
            ColliderTransform.localScale=Vector3.Lerp(ColliderTransform.localScale,new Vector3(1f,1f,1f),Time.deltaTime*15f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Jump();
            }
        }

        
    }

    public void Jump()
    {
        Rgbody.AddForce(0,JumpSpeed,0,ForceMode.VelocityChange);
        _jumpFrameCounter=0;
        
    }

    private void FixedUpdate()
    {
        if (!Grounded)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,0f);
        }
        Rgbody.AddForce(0f,0f,0f,ForceMode.VelocityChange);

        float speedmultiplayer=1f;

        if (Grounded==false)
        {
            speedmultiplayer=0.01f;
        
            if (Rgbody.velocity.x>MaxSpeed && Input.GetAxis("Horizontal")>0)
            {
                speedmultiplayer=0f;
            }
            if (Rgbody.velocity.x<-MaxSpeed && Input.GetAxis("Horizontal")<0)
            {
                speedmultiplayer=0f;
            }
        }

        Rgbody.AddForce(Input.GetAxis("Horizontal")*MoveSpeed*speedmultiplayer,0,0,ForceMode.VelocityChange);
       
        if (Grounded)
        {
            Rgbody.AddForce(-Rgbody.velocity.x*Friction,0,0,ForceMode.VelocityChange);
            transform.rotation=Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);
        }

        _jumpFrameCounter+=1;
        if (_jumpFrameCounter==2)
        {
            Rgbody.freezeRotation=false;
            
            if (Rgbody.velocity.x>0)
            Rgbody.AddRelativeTorque(0f,0f,-5f,ForceMode.VelocityChange);
            else Rgbody.AddRelativeTorque(0f,0f,5f,ForceMode.VelocityChange);
        }
    }
    
  

    private void OnCollisionStay(Collision other)
    {
        for (int i=0;i<other.contactCount;i++)
        {
            float angle = Vector3.Angle(other.contacts[i].normal,Vector3.up);
            if (angle < 45f)
            {
                Grounded=true;
                Rgbody.freezeRotation=true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Grounded=false;
    }
}
