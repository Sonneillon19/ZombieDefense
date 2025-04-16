using UnityEngine;

public class TallerInteractivo : MonoBehaviour
{
    public GameObject interactionPanel; // ← NO TextMeshProUGUI, sino el panel completo

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
        }
    }
    
    void Start()
    {
        if (interactionPanel == null)
        {
            interactionPanel = GameObject.Find("UI_InteractionPrompt");
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacción con el Taller iniciada...");
        }
    }
}
