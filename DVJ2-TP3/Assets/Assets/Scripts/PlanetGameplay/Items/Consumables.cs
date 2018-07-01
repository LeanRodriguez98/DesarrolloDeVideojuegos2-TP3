using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Consumable")]
public class Consumables : Item {

    public int healthRecovery = 0;
    public int damageModifier = 0;
    public float speedModifier = 0;

    public override void Use()
    {
        PlayerController.instancie.life += healthRecovery;
        PlayerController.instancie.damage += damageModifier;
        PlayerController.instancie.speed += speedModifier;

        RemoveFromInventory();
        base.Use();
    }
}
