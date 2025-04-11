using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 40;
    private int currentHealth;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;

        if (animator != null)
        {
            animator.SetTrigger("Hit"); // 🔥 Aquí se lanza la reacción de golpe
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (animator != null)
        {
            animator.SetTrigger("Die"); // 🔥 Aquí se lanza la animación de muerte
        }

        Destroy(gameObject, 3f); // Elimina tras 3 segundos
    }
}
