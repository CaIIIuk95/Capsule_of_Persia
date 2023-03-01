using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    
    private bool _isActive=true;
    public Activator Activator;
    private float _activateDistance=20f;

    public void Start()
    {
        var ScriptEnemyHealth=GetComponent<EnemyHealth>();
        if (GetComponent<EnemyHealth>())
        {
            _activateDistance=ScriptEnemyHealth.ActivateDistance;
        }
        Activator=FindObjectOfType<Activator>();
        //Activator.ObjectsToActivate.Add(this.gameObject);    
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance=Vector3.Distance(transform.position,playerPosition);

        if (_isActive)
        {
            if (distance>_activateDistance+2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance<_activateDistance)
            {
                Activate();
            }
        }
    }

    public void Activate()
    {
        _isActive=true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive=false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Activator.ObjectsToActivate.Remove(this);
    }
}
