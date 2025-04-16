using UnityEngine;
using System.Collections;

public class RescueNPC : MonoBehaviour
{
    public string npcName = "Constructor";
    public GameObject unlockStructurePrefab; // Prefab a desbloquear (ej. taller)
    public Transform baseSpawnPoint;         // Dónde aparecerá la estructura
    public GameObject messageUI;             // Panel de mensaje UI
    private bool rescued = false;

    void OnTriggerEnter(Collider other)
    {
        if (!rescued && other.CompareTag("Player"))
        {
            rescued = true;

            Debug.Log(npcName + " rescatado!");

            if (unlockStructurePrefab != null && baseSpawnPoint != null)
            {
                Instantiate(unlockStructurePrefab, baseSpawnPoint.position, Quaternion.identity);
            }

            if (messageUI != null)
            {
                messageUI.SetActive(true);
                StartCoroutine(HideMessageAfterDelay());
            }

            // Mueve al NPC a la base como prueba visual
            transform.position = baseSpawnPoint.position;
        }
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }
    }
}
