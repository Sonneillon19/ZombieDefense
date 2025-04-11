using UnityEngine;

public class LootPickup : MonoBehaviour
{
    public WeaponData weaponData;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.EquipWeapon(weaponData);
                Destroy(gameObject); // El objeto desaparece
            }
        }
    }
}
