using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health=5;
    public int MaxHealth=8;
    private bool _invulnerable=false;
    public AudioSource TakeDamageSound, AddHealthSound;
    public HealthUI HealthUI;
    public Image DamageImage;
    public Blink Blink;
    public UnityEvent EventOnTakeDamage;

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            Health -=damageValue;
            
            if (Health <=0)
            {
                Health=0;
                Die();
            }
            _invulnerable=true;
            Invoke("StopInvulnerable",1f);
            //TakeDamageSound.Play();
            HealthUI.DisplayHealth(Health);
            //StartCoroutine(ShowEffect(true));
            //Blink.StartBlink();

            EventOnTakeDamage.Invoke();
        }

    }

    public void StartEffect(bool _isDamage)
    {
        StartCoroutine(ShowEffect(_isDamage));
    }

    void StopInvulnerable()
    {
        _invulnerable=false;
    }

    public void AddHealth(int healthValue)
    {
        Health +=healthValue;
        if (Health>MaxHealth)
        {
            Health=MaxHealth;
        }
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);
        StartCoroutine(ShowEffect(false));
    }
    void Die()
    {

    }

    public IEnumerator ShowEffect(bool _isDamage)
    {
        DamageImage.enabled=true;
        for (float t = 1; t > 0; t-=Time.deltaTime)
        {
            if (_isDamage)
            DamageImage.color=new Color(1,0,0,t);
            else DamageImage.color=new Color(0,1,0,t);
            yield return null;
        }
        DamageImage.enabled=false;
    }








}
