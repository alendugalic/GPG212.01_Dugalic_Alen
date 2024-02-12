using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float baseDamage;
    [SerializeField] private Dictionary<string, float> weaknesses = new Dictionary<string, float>();

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();

        weaknesses["Fire"] = 2.0f;
        weaknesses["Ice"] = 4f;
        weaknesses["Electric"] = 3f;
    }

    public void TakeDamage(float incomingDamage, string damageType)
    {
        float finalDamage = CalculateFinalDamage(incomingDamage, damageType);
        health.TakeDamage(finalDamage);

        if (health.GetCurrentHealth() <= 0)
        {
            Die();
        }
    }
    public float GetWeaknessMultiplier(string damageType)
    {
        return weaknesses.ContainsKey(damageType) ? weaknesses[damageType] : 1.0f;
    }


    private float CalculateFinalDamage(float incomingDamage, string damageType)
    {
        float bonusMultiplier = weaknesses.ContainsKey(damageType) ? weaknesses[damageType] : 1.0f;
        return incomingDamage * bonusMultiplier;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
