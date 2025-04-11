using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 0;
    public TextMeshProUGUI waveText;
    public Button startWaveButton;

    public GameObject enemyPrefab;
    public Transform enemySpawnPoint;

    public int enemiesPerWave = 5;
    public float spawnDelay = 1f;

    void Start()
    {
        UpdateWaveText();
        startWaveButton.onClick.AddListener(() => StartCoroutine(StartWave()));
    }

    System.Collections.IEnumerator StartWave()
    {
        currentWave++;
        UpdateWaveText();

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void UpdateWaveText()
    {
        waveText.text = "Oleada: " + currentWave;
    }
}
