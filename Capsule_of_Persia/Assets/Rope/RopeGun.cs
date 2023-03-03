using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    public SpringJoint SpringJoint;
    public Transform SpringStart;
    private float _lenght;
    public RopeRenderer RopeRenderer;
    public RopeState CurrentRopeState;
    public PlayerMove PlayerMove;

    void Update()
    {
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.E))
        {
            Shot();
        }
        if (CurrentRopeState==RopeState.Fly)
        {
            float distance=Vector3.Distance(SpringStart.position,Hook.transform.position);
            if (distance>10f)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState=RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (CurrentRopeState == RopeState.Active)
            {
                if (PlayerMove.Grounded==false)
                {
                    PlayerMove.Jump();
                }
            }
            DestroySpring();
        }
        if(CurrentRopeState==RopeState.Fly || CurrentRopeState==RopeState.Active)
        {
            RopeRenderer.Draw(SpringStart.position,Hook.transform.position,_lenght);
        }
    }

    void Shot()
    {
        _lenght=1f;
        if (SpringJoint)
        {
            Destroy(SpringJoint); 
        }
        Hook.gameObject.SetActive(true);
        Hook.StopFix();
        Hook.transform.position=Spawn.position;
        Hook.transform.rotation=Spawn.rotation;
        Hook.Rigidbody.velocity=Spawn.forward*Speed;

        CurrentRopeState=RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint==null)
        {
            SpringJoint=gameObject.AddComponent<SpringJoint>();
            SpringJoint.connectedBody=Hook.Rigidbody;
            SpringJoint.autoConfigureConnectedAnchor=false;
            SpringJoint.anchor=SpringStart.localPosition;
            SpringJoint.connectedAnchor=Vector3.zero;
            SpringJoint.spring=100f;
            SpringJoint.damper=5f;

            _lenght=Vector3.Distance(SpringStart.position,Hook.transform.position);
            SpringJoint.maxDistance=_lenght;
            CurrentRopeState=RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState=RopeState.Disabled;
            Hook.gameObject.SetActive(false);
            RopeRenderer.Hide();
        }
    }
}
