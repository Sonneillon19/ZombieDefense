using UnityEngine;

public class TallerInteractivo : MonoBehaviour
{
    public GameObject interactionPanel; // Texto: "Presiona E para interactuar"
    public GameObject menuPanel;        // Menú completo del Taller

    private bool isPlayerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionPanel != null)
                interactionPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionPanel != null)
                interactionPanel.SetActive(false);
            if (menuPanel != null)
                menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Menú del Taller abierto.");
            if (menuPanel != null)
                menuPanel.SetActive(true);
        }
    }
}
