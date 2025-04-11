using UnityEngine;

[System.Serializable]
public class LootItem
{
    public GameObject itemPrefab;
    [Range(0f, 1f)] public float dropChance; // Probabilidad de drop (0.5 = 50%)
}

public class LootTable : MonoBehaviour
{
    public LootItem[] possibleLoot;

    public void DropLoot(Vector3 position)
    {
        foreach (LootItem loot in possibleLoot)
        {
            if (loot.itemPrefab == null) continue; // Protege contra null
            
            if (Random.value <= loot.dropChance)
            {
                Instantiate(loot.itemPrefab, position, Quaternion.identity);
                break; // Solo dropea 1 objeto, quita esta línea si quieres que pueda dropear varios
            }
        }
    }
}
