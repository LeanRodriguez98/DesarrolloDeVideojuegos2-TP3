using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button removeButton;

    private Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.gameObject.SetActive(true);
        removeButton.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.gameObject.SetActive(false);
        removeButton.gameObject.SetActive(false);
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        ClearSlot();
    }

    public void Use()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
