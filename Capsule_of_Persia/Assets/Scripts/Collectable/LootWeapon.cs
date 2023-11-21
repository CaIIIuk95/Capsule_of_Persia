using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponsArray;
    [SerializeField] private GameObject Weapon;
    [SerializeField] private GameObject Player;
    [SerializeField] private int CurrWeaponIndex = 0;
    [SerializeField] private int BulletCount = 10;
    [SerializeField] private float BulletSpeed = 20f;
    [SerializeField] private float ShotPeriod = 0.2f;

    private GameObject _currGun;


    private void Start()
    {
        Player = FindObjectOfType<PlayerHealth>().gameObject;
        ChangeGun();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            ChangeGun();
    }

    private void FixedUpdate()
    {
        Weapon.transform.Rotate(new Vector3(0f, 1f, 0));
    }

    public void ChangeGun()
    {
        Destroy(_currGun);

        float divideValue = 2f;
        if (CurrWeaponIndex > 4)
        {
            divideValue = 4f;
        }

        _currGun = Instantiate(weaponsArray[CurrWeaponIndex], Weapon.transform.position, Quaternion.identity);
        float valueZ = _currGun.GetComponent<MeshRenderer>().bounds.size.z / divideValue;
        _currGun.transform.parent = Weapon.transform;
        _currGun.transform.position = transform.localPosition - new Vector3(0f, 0f, valueZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                Player.GetComponent<PlayerChangeGun>().ChangeWeapon(_currGun.gameObject, CurrWeaponIndex, BulletSpeed, ShotPeriod, BulletCount);
                Destroy(gameObject);
            }
    }
}
