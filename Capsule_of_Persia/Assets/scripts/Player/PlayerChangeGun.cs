using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChangeGun : MonoBehaviour
{
    public GameObject Pistol;
    
    public Gun GunScript;
    public Transform Spawn;
    private Vector3 _spawnFirstPosition;
    private GameObject _pistolModel;
    private GameObject _currGun;

    public int _currGunIndex;
    // Start is called before the first frame update
    void Start()
    {
        _spawnFirstPosition=Spawn.localPosition;
        _currGun=Pistol.transform.GetChild(0).gameObject;
        _pistolModel=_currGun;
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeWeapon(GameObject Gun,int GunIndex, float BulletSpeed, float BulletPeriod, int BulletCount)
    {
        
        Transform prevGunTransform=_currGun.transform;
        Destroy(_currGun);
        _currGunIndex=GunIndex;
        _currGun=Instantiate(Gun,prevGunTransform.position,prevGunTransform.rotation);
        _currGun.transform.parent=Pistol.transform;
        _currGun.gameObject.transform.localScale=new Vector3(1.4f,1.4f,1.4f);
        GunScript.GunIndex=GunIndex;
        GunScript.BulletSpeed=BulletSpeed;
        GunScript.ShotPeriod=BulletPeriod;
        GunScript.BulletCount=BulletCount;

        Vector3 sdvig=new Vector3(0f,0f,0f);
        switch (GunIndex)
        {
            case 2:
            sdvig=new Vector3(0f,0.055f,0f);
            break;

            case 3:
            sdvig=new Vector3(0f,-0.11f,0.09f);
            break;

            case 4:
            case 6:
            sdvig=new Vector3(0f,-0.054f,0.42f);
            break;
            
            case 5:
            case 9:
            sdvig=new Vector3(0f,-0.09f,0.37f);
            break;

            case 7:
            case 10:
            sdvig=new Vector3(0f,-0.09f,0.60f);
            break;
 
            case 13:
            sdvig=new Vector3(0f,0,0.42f);
            break;
            
            case 14:
            sdvig=new Vector3(0f,-0.097f,0.42f);
            break;

            case 8:
            sdvig=new Vector3(0f, 0f,0.75f);
            break;

            case 12:
            sdvig=new Vector3(0f, 0f,0.04f);
            break;

            case 11:
            sdvig=new Vector3(0f,-0.035f,0.65f);
            break;
        }
        Spawn.transform.localPosition=_spawnFirstPosition+sdvig;

    }
}
