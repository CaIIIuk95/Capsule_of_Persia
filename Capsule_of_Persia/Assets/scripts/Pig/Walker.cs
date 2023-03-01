using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}


public class Walker : MonoBehaviour
{
    public Transform PosA,PosB;
    public float Speed,StopTime;
    private bool _isStopped;
    public Direction CurrentDirection;
     public Transform RayStart;

    
    public UnityEvent EventOnRightTarget,EventOnLeftTarget;
   

    // Start is called before the first frame update
    void Start()
    {
        PosA.parent=null;
        PosB.parent=null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStopped==true)
        {
            return;
        }

        if (CurrentDirection==Direction.Left)
        {
            transform.position-=new Vector3(Time.deltaTime * Speed,0f,0f);
            if (transform.position.x<PosA.position.x)
            {
                CurrentDirection=Direction.Right;
                _isStopped=true;
                Invoke("ContinueWalk",StopTime);
                EventOnLeftTarget.Invoke();
            }
        } 
        else
        {
            transform.position+=new Vector3(Time.deltaTime * Speed,0f,0f);
            if (transform.position.x>PosB.position.x)
            {
                CurrentDirection=Direction.Left;
                _isStopped=true;
                Invoke("ContinueWalk",StopTime);
                EventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(RayStart.position,Vector3.down,out hit))
        {
            transform.position=new Vector3(transform.position.x,hit.point.y+0.24f,0f);
            //Debug.DrawRay(RayStart.position,Vector3.down*2f,Color.white);
            //transform.position=hit.point;
        }
    }

    void ContinueWalk()
    {
         _isStopped=false;
    }
}
