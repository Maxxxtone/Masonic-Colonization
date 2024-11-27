using UnityEngine;

[CreateAssetMenu(fileName = "New Item SO", menuName = "Pickups/Item")]
public class PickupItemSO : ScriptableObject
{
    [SerializeField] private string _itemName;
    [SerializeField] private Sprite _icon;
    public string ItemName => _itemName;
    public Sprite Icon => _icon;
}
