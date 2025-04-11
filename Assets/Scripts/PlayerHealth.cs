using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(DamageFlash());

        currentHealth -= amount;
        UpdateHealthUI();

        Debug.Log("Jugador recibió daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Vida: " + currentHealth;
    }

    void Die()
    {
        Debug.Log("¡Jugador ha muerto!");

        GameOverManager goManager = FindObjectOfType<GameOverManager>();
        if (goManager != null)
        {
            goManager.ShowGameOver();
        }

        gameObject.SetActive(false); // Desactiva al jugador
    }


    IEnumerator DamageFlash()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
        }
    }

}
