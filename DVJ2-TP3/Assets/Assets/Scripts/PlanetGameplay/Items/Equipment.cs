using UnityEngine;

public enum EquipmentSlot
{
    Head,
    Chest,
    Weapon,
    Shield,
    Legs
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot slot;

    public int armorModiefier;
    public int damageModifier;

    public override void Use()
    {
        EquipmentManager.instance.Equip(this);
        Debug.Log("Equiping " + name);
    }
}
