using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawn : MonoBehaviour
{
    public GameObject Acorn;
    public GameObject P1,P2,P3;
    
    [ContextMenu("Spawn")]
    public void Spawn()
    {
        
        GameObject A1=Instantiate(Acorn,P1.transform.position,Quaternion.Euler(P1.transform.forward));
        GameObject A2=Instantiate(Acorn,P2.transform.position,Quaternion.Euler(P2.transform.forward));
        GameObject A3=Instantiate(Acorn,P3.transform.position,Quaternion.Euler(P3.transform.forward));

        A1.GetComponent<Rigidbody>().AddForce(P1.transform.forward*300f);
        A2.GetComponent<Rigidbody>().AddForce(P2.transform.forward*300f);
        A3.GetComponent<Rigidbody>().AddForce(P3.transform.forward*300f);
        
    }
}
