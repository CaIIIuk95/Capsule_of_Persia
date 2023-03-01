using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    private Rigidbody PlayerRigidbody;
    public Transform Spawn;//Bullet spawn pos
    public GameObject DefaultPistol;//Default pistol prefab
    public Text BulletCountText;
    private PlayerChangeGun PlayerChangeGunScript;
    
    
    public float BulletSpeed=10f;
    public float ShotPeriod = 0.2f;
    public int BulletCount=0;
    public int GunIndex=0;
    public AudioSource ShotSound;
    public GameObject Flash;
    private float _timer;
    public GameObject Player;
    
    public void Start()
    {
        Player=FindObjectOfType<PlayerChangeGun>().gameObject;
        PlayerChangeGunScript=Player.GetComponent<PlayerChangeGun>();
        PlayerRigidbody=Player.GetComponent<Rigidbody>();
               
    }

    void Update()
    {
        _timer+=Time.deltaTime;
        
        if (GunIndex!=0)
        {
            if (BulletCount>0)
            {
                BulletCountText.text=BulletCount.ToString();
                if (_timer>ShotPeriod)
                {       
                    if (Input.GetMouseButton(0))
                    {
                        Shot();
                    }
                }
            }
            else
            {  
                BulletCountText.text="∞";
                PlayerChangeGunScript.ChangeWeapon(DefaultPistol,0,20f,1f,0);
            }
        }
        else
        {
            if (_timer>ShotPeriod)
            {       
                if (Input.GetMouseButton(0))
                {
                    Shot();
                }
            }
        }
    }
    

    public void HideFlash()
    {
        Flash.SetActive(false);

    }

    

    public void Shot()
    {
        _timer=0f;
        GameObject newBullet=Instantiate(BulletPrefab,Spawn.position,Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity=Spawn.forward*BulletSpeed;
        ShotSound.Play();
        Flash.SetActive(true);
        if (GunIndex!=0)
        BulletCount--;
        PlayerRigidbody.AddForce(-Spawn.forward*2f,ForceMode.Impulse);
        

        Invoke("HideFlash",0.12f);
    }

    
}