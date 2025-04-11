using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float attackRate;
    public Sprite icon;
    public ItemRarity rarity;
}
