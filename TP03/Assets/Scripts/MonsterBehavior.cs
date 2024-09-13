using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI Health Bars

public class MonsterBehavior : MonoBehaviour
{
    public float attackRange = 5f;    // Range within which the monster will attack
    public float attackDamage = 10f;  // Amount of damage per attack
    public float health = 100f;       // Monster's health
    public Slider healthBar;          // Monster health UI
    private Animator animator;
    private Transform player;         // Player reference
    private bool isAttacking = false; // Check if the monster is attacking

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform; // Find player by tag
        healthBar.maxValue = health;  // Set the health bar's max value
        healthBar.value = health;     // Initialize health bar to full
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        // If the player is within attack range, attack the player
        if (distance <= attackRange && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    // Coroutine for attacking the player
    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        animator.SetTrigger("Attack"); // Play attack animation
        yield return new WaitForSeconds(1f); // Assume 1 second for the attack to finish

        // Deal damage to the player if within range
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(2f); // Wait before next attack
        isAttacking = false;
    }

    // Monster takes damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            Die();
        }
    }

    // Handle monster death
    void Die()
    {
        animator.SetTrigger("Die");
        // Destroy or disable the monster after death animation
        Destroy(gameObject, 2f); // Optional: destroy the monster after 2 seconds
    }
}
