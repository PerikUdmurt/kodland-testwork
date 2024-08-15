using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public ProgressBar healthBar;
    public Shield shield;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        healthBar.SetMaxValue(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (shield != null)
            if (shield.isActive)
                return;

        currentHealth -= damage;
        healthBar.SetValue(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameManager.Killed(this.gameObject.tag);
        Destroy(gameObject);
    }
}
