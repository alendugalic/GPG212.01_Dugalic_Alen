using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    private float currentHealth;

    public int numOfEggs;
    public Image[] hearts;
    public Sprite fullEgg;
    public Sprite emptyEgg;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
   
        currentHealth -= damage;
        UpdateHealthUI();
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        LevelManager.manager.GameOver();
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    private void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullEgg;
            }
            else
            {
                hearts[i].sprite = emptyEgg;
            }

            if (i < numOfEggs)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
