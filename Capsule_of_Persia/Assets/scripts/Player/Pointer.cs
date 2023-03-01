using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform aim;
    public Camera PlayerCamera;
    public Transform Player;
    public Rigidbody PlayerRigidbody;
    public PlayerMove PlayerMove;

    void Update()
    {
        Ray ray=PlayerCamera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward,Vector3.zero);

        float distance;
        plane.Raycast(ray,out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position=point;

        Vector3 toAim=aim.position-transform.position;
        transform.rotation=Quaternion.LookRotation(toAim);

        //if (PlayerMove.Grounded)
        {
            if (aim.transform.position.x<Player.transform.position.x-1)
            {
                Player.transform.localRotation=Quaternion.Lerp(Player.transform.localRotation,Quaternion.Euler(0f, 30f, 0f),Time.deltaTime*15f);
            }
            else if (aim.transform.position.x>Player.transform.position.x+1)
            {
                Player.transform.localRotation=Quaternion.Lerp(Player.transform.localRotation,Quaternion.Euler(0f, -30f, 0f),Time.deltaTime*15f);
            } else Player.transform.localRotation=Quaternion.Lerp(Player.transform.localRotation,Quaternion.Euler(0f, 0f, 0f),Time.deltaTime*15f);
        }

        
        
   
    }
}
