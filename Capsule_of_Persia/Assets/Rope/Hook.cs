using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody;

    public Collider Collider;
    public Collider PlayerCollider;
    public RopeGun RopeGun;

    private void Start()
    {
        Physics.IgnoreCollision(Collider,PlayerCollider);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_fixedJoint==null)
        {
            _fixedJoint=gameObject.AddComponent<FixedJoint>();
            if (other.rigidbody)
            {
                _fixedJoint.connectedBody=other.rigidbody;
            }
            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if(_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
