using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemies : MonoBehaviour
{
   [SerializeField] public float speed = 3f; 
   [SerializeField] public int health = 3;
   [SerializeField] public int scoreValue;
   [SerializeField] private int damageAmount;
    private Transform targetEggs;
    private void Start()
    {
        targetEggs = GameObject.FindGameObjectWithTag("EggNest").transform;

        if (targetEggs == null)
        {
            Debug.LogError("Target not found!");
        }
    }

    void Update()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        if(targetEggs != null)
        {
            Vector2 direction = (targetEggs.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            LevelManager.manager.IncreaseScore(scoreValue);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EggNest"))
        { 
            DamageTarget(other.gameObject);
 
            Destroy(gameObject);
        }
    }

    void DamageTarget(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damageAmount);
        }
    }
}
