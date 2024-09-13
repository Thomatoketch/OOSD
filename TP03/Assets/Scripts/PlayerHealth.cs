using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI; // For UI Health Bars

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; // Player's health
    public Slider healthBar;    // Health bar UI
    private Animator animator;

    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        animator = GetComponent<Animator>();
    }

    // Function to take damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            Die();
        }
    }

    // Handle player death
    void Die()
    {
        UnityEngine.Debug.Log("Player Died!");
        animator.SetTrigger("Die"); // Play death animation
        // Disable player controls or show Game Over screen
    }
}
