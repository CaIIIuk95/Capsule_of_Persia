using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapon : MonoBehaviour
{
    public GameObject[] WeaponsArray;
    public int CurrWeaponIndex=0;
    public GameObject Weapon;
    private GameObject _currGun;
    public GameObject Player;
    public float BulletSpeed=20f;
    public float ShotPeriod=0.2f;
    public int BulletCount=10;
    // Start is called before the first frame update
    void Start()
    {
        Player=FindObjectOfType<PlayerHealth>().gameObject;
        ChangeGun();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        ChangeGun();
    }
   
    void FixedUpdate()
    {
        Weapon.transform.Rotate(new Vector3(0f,1f,0));
    }

    public void ChangeGun()
    {
        Destroy(_currGun);
        
        float del_val=2f;
        if (CurrWeaponIndex>4)
        {
            del_val=4f;
        }
        else 
        {
            del_val=2f;
        }

        _currGun=Instantiate(WeaponsArray[CurrWeaponIndex],Weapon.transform.position,Quaternion.identity);
        float val_z=_currGun.GetComponent<MeshRenderer>().bounds.size.z/del_val;
        _currGun.transform.parent=Weapon.transform;
        _currGun.transform.position=transform.localPosition-new Vector3(0f,0f,val_z);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            Player.GetComponent<PlayerChangeGun>().ChangeWeapon(_currGun.gameObject,CurrWeaponIndex,BulletSpeed,ShotPeriod,BulletCount);
            Destroy(gameObject);
        }
    }
}
