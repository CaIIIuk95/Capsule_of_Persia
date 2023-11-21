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
    [SerializeField] private Transform posA;
    [SerializeField] private Transform posB;
    [SerializeField] private float speed;
    [SerializeField] private float stopTime;
    [SerializeField] private Direction currentDirection;
    [SerializeField] private Transform rayStart;

    private bool _isStopped;

    public UnityEvent EventOnRightTarget;
    public UnityEvent EventOnLeftTarget;



    private void Start()
    {
        posA.parent = null;
        posB.parent = null;
    }

    private void Update()
    {
        if (_isStopped == true)
        {
            return;
        }

        if (currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x < posA.position.x)
            {
                currentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", stopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
            if (transform.position.x > posB.position.x)
            {
                currentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", stopTime);
                EventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(rayStart.position, Vector3.down, out hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.24f, 0f);
            //Debug.DrawRay(RayStart.position,Vector3.down*2f,Color.white);
            //transform.position=hit.point;
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
