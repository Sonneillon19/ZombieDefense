using UnityEngine;
using System.Collections;

public class RescueNPC : MonoBehaviour
{
    public string npcName = "Constructor";
    public GameObject unlockStructurePrefab;
    public Transform baseSpawnPoint;
    public GameObject messageUI;

    // Referencias globales a los objetos de UI en escena
    public GameObject interactionPanel;
    public GameObject menuPanel;

    private bool rescued = false;

    void OnTriggerEnter(Collider other)
    {
        if (!rescued && other.CompareTag("Player"))
        {
            rescued = true;
            Debug.Log(npcName + " rescatado!");

            // Instanciar el Taller
            if (unlockStructurePrefab != null && baseSpawnPoint != null)
            {
                GameObject newStructure = Instantiate(unlockStructurePrefab, baseSpawnPoint.position, Quaternion.identity);

                // Asignar los paneles manualmente al Taller
                TallerInteractivo tallerScript = newStructure.GetComponent<TallerInteractivo>();
                if (tallerScript != null)
                {
                    Debug.Log("✅ TallerInteractivo encontrado, asignando paneles...");
                    tallerScript.interactionPanel = interactionPanel;
                    tallerScript.menuPanel = menuPanel;
                }
                else
                {
                    Debug.LogError("❌ TallerInteractivo no encontrado en el prefab instanciado.");
                }
            }

            if (messageUI != null)
            {
                messageUI.SetActive(true);
                StartCoroutine(HideMessageAfterDelay());
            }

            // (Opcional) Mover el NPC a la base
            transform.position = baseSpawnPoint.position;
        }
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        if (messageUI != null)
            messageUI.SetActive(false);
    }
}
