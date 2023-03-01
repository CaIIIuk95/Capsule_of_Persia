using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate=new List<ActivateByDistance>();
    private Transform PlayerTransform;
    

    // public static void Instantiate_Enemy(GameObject original,Vector3 position,Quaternion rotation)
    // {
    //     GameObject ist=Instantiate(original,position,rotation);           
    // }

    void Start()
    {
        
        PlayerTransform=FindObjectOfType<PlayerHealth>().transform;
        Invoke("AddEnemiesToDistanceList",Time.unscaledDeltaTime);
    }

    void FixedUpdate()
    {
        if (ObjectsToActivate.Count>0)
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }

    void AddEnemiesToDistanceList()
    {
        
        var tempList=FindObjectsOfType<EnemyHealth>();
        for (int i = 0; i < tempList.Length; i++)
        {
            if (!tempList[i].GetComponent<ActivateByDistance>())
            {
                tempList[i].gameObject.AddComponent<ActivateByDistance>();
                ObjectsToActivate.Add(tempList[i].gameObject.GetComponent<ActivateByDistance>());
            }
        }
        
        
    }
}
