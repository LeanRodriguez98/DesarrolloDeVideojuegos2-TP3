using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

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

    public delegate void OnItemChange();
    public OnItemChange itemChangeCallBack;

    public List<Item> items = new List<Item>();
    public int maxSpace = 5;

    public bool Add(Item item) {
        if (items.Count >= maxSpace)
            return false;

        items.Add(item);
        if (itemChangeCallBack != null)
            itemChangeCallBack.Invoke();

        return true;
    }
    public void Remove(Item item){
        items.Remove(item);

        if (itemChangeCallBack != null)
            itemChangeCallBack.Invoke();
    }
}
