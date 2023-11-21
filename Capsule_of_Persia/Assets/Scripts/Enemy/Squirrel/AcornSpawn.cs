using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawn : MonoBehaviour
{
    [SerializeField] private GameObject acorn;
    [SerializeField] private GameObject p1, p2, p3;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        GameObject A1 = Instantiate(acorn, p1.transform.position, Quaternion.Euler(p1.transform.forward));
        GameObject A2 = Instantiate(acorn, p2.transform.position, Quaternion.Euler(p2.transform.forward));
        GameObject A3 = Instantiate(acorn, p3.transform.position, Quaternion.Euler(p3.transform.forward));

        A1.GetComponent<Rigidbody>().AddForce(p1.transform.forward * 300f);
        A2.GetComponent<Rigidbody>().AddForce(p2.transform.forward * 300f);
        A3.GetComponent<Rigidbody>().AddForce(p3.transform.forward * 300f);
    }
}
