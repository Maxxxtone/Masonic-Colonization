using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Items Database", menuName = "Pickups/Items Database")]
public class ResourcesDatabase : ScriptableObject
{
    //[SerializeField] private Dictionary<PickupItemSO, int> _resources;
    [SerializeField] private List<InventoryItem> _resources;
    public void Add(PickupItemSO item)
    {
        _resources ??= new List<InventoryItem>();
        var itemToAdd = _resources.Find(i => i.Item == item);
        if (itemToAdd != null)
        {
            itemToAdd.Quantity += 1;
        }
        else
        {
            _resources.Add(new InventoryItem { Item = item, Quantity = 1 });
        }
    }
}
[System.Serializable]
public class InventoryItem
{
    public PickupItemSO Item;
    public int Quantity;
}
