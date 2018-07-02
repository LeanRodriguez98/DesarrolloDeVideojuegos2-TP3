using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnEquipChange();
    public OnEquipChange equipCallBack;

    public Equipment[] currentEquipment;

    private void Start()
    {
        int cantSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[cantSlots];
    }

    public void Equip(Equipment newEquipment){
        currentEquipment[(int)newEquipment.slot] = newEquipment;
    }
}
