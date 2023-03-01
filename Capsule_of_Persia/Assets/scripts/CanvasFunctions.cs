using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFunctions : MonoBehaviour
{
    private Color _defColor;

    private void Start()
    {
        _defColor=gameObject.GetComponent<Renderer>().material.color;
    }

    public void SetWidth(float Value)
    {
        transform.localScale=new Vector3(Value,transform.localScale.y,transform.localScale.z);
    }
    public void SetHeight(float Value)
    {
        transform.localScale=new Vector3(transform.localScale.x,Value,transform.localScale.z);
    }
    public void Dropbox_vl(int Value)
    {
        switch(Value)
        {
            case 0:
            gameObject.GetComponent<Renderer>().material.color=Color.green;
            
            break;
            case 1:
            gameObject.GetComponent<Renderer>().material.color=Color.yellow;
            break;
            case 2:
            
            gameObject.GetComponent<Renderer>().material.color=Color.red;
            break;
             case 3:
            
            gameObject.GetComponent<Renderer>().material.color=_defColor;
            break;


        }
    }
}
