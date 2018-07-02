using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour {

    public Image Head;
    public Image Chest;
    public Image Sword;
    public Image Shield;
    public Image Legs;

    public GameObject UI;

    private EquipmentManager equipment;

    private void Start()
    {
        equipment = EquipmentManager.instance;
        equipment.equipCallBack += UpdateUI;
    }

    private void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.E))
            UI.SetActive(!UI.activeSelf);
    }

    public void UpdateUI()
    {
        if (equipment.currentEquipment[(int)EquipmentSlot.Head])
        {
            Head.gameObject.SetActive(true);
            Head.sprite = equipment.currentEquipment[(int)EquipmentSlot.Head].icon;
        }
        if (equipment.currentEquipment[(int)EquipmentSlot.Chest])
        {
            Chest.gameObject.SetActive(true);
            Chest.sprite = equipment.currentEquipment[(int)EquipmentSlot.Chest].icon;
        }
        if (equipment.currentEquipment[(int)EquipmentSlot.Weapon])
        {
            Sword.gameObject.SetActive(true);
            Sword.sprite = equipment.currentEquipment[(int)EquipmentSlot.Weapon].icon;
        }
        if (equipment.currentEquipment[(int)EquipmentSlot.Shield])
        {
            Shield.gameObject.SetActive(true);
            Shield.sprite = equipment.currentEquipment[(int)EquipmentSlot.Shield].icon;
        }
        if (equipment.currentEquipment[(int)EquipmentSlot.Legs])
        {
           Legs.gameObject.SetActive(true);
           Legs.sprite = equipment.currentEquipment[(int)EquipmentSlot.Legs].icon;
        }
    }
}
