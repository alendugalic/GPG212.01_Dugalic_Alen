using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        //need to add the animation (using same as first game)
        currentHealth -= damage;

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        LevelManager.manager.GameOver();
        //add death animations or other logic here
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
