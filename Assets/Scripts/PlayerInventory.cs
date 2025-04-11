using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public WeaponData equippedWeapon;
    public TextMeshProUGUI weaponText;

    private PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        UpdateWeaponText();
    }

    public void EquipWeapon(WeaponData newWeapon)
    {
        equippedWeapon = newWeapon;
        controller.attackDamage = newWeapon.damage;
        controller.attackRate = newWeapon.attackRate;

        UpdateWeaponText();
        Debug.Log("Arma equipada: " + newWeapon.weaponName);
    }

   void UpdateWeaponText()
    {
        if (weaponText != null && equippedWeapon != null)
        {
            string color = GetColorByRarity(equippedWeapon.rarity);
            weaponText.text = $"<color={color}>Arma: {equippedWeapon.weaponName}</color>";
        }
    }

    string GetColorByRarity(ItemRarity rarity)
    {
        switch (rarity)
        {
            case ItemRarity.Common: return "gray";
            case ItemRarity.Rare: return "green";
            case ItemRarity.SuperRare: return "blue";
            case ItemRarity.Epic: return "purple";
            case ItemRarity.Legendary: return "orange";
            default: return "white";
        }
    }

}
