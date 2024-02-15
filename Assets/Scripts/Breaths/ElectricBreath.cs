using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBreath : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public int baseDamage = 1;
    [SerializeField] public float bonusDamageMultiplier = 2.0f;
    [SerializeField] public string targetTag = "Knight";
    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is on the "EnemyLayer"
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            int totalDamage = baseDamage;

            // Check if the collided object has the specified tag for bonus damage
            if (other.gameObject.CompareTag(targetTag))
            {
                totalDamage = Mathf.RoundToInt(baseDamage * bonusDamageMultiplier);
            }

            // Apply damage to the enemy
            Enemies enemy = other.GetComponent<Enemies>();
            if (enemy != null)
            {
                enemy.TakeDamage(totalDamage);
            }
        }
    }
}
