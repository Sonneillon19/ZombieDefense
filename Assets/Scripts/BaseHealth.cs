using UnityEngine;
using TMPro;

public class BaseHealth : MonoBehaviour
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
        currentHealth -= amount;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("¡La base ha sido destruida!");
            // Aquí podrías activar una pantalla de Game Over
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Salud Base: " + currentHealth;
    }
}
