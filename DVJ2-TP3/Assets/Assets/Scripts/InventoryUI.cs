using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemParent;
    public GameObject UI;

    private Inventory inventory;
    private InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.itemChangeCallBack += UpdateUI;

        slots = itemParent.GetComponentsInChildren<InventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.I))
            UI.SetActive(!UI.activeSelf);
	}

    void UpdateUI() {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
