using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public bool isVulnerableToFire = false;
    [SerializeField] public bool isVulnerableToIce = false;
    [SerializeField] public bool isVulnerableToElectric = false;
    private void Start()
    {
        Health health = GetComponent<Health>();
    }
    public void TakeDamage(float damage)
    {
        float finalDamage = isVulnerableToFire ? damage * 2 : damage;
        health -= finalDamage;

        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {  
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        If(isVulnerableToFire = true)
        {


        }
    }
}
