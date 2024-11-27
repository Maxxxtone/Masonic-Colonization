using ObjectPool;
using System.Collections.Generic;
using UnityEngine;

public class RoomResourcesHolder : MonoBehaviour
{
    [SerializeField] private PickupItem _pickupItem;
    [SerializeField] private int _pickupsToSpawn = 15;
    private List<DestroyableResource> _resources;
    private BasePool<PickupItem> _pickupItemsPool;
    public BasePool<PickupItem> PickupItemsPool => _pickupItemsPool;
    private void Start()
    {
        _resources = new List<DestroyableResource>();
        _pickupItemsPool = new BasePool<PickupItem>(_pickupItem.gameObject, _pickupsToSpawn, "PickupsPool");
        for (int i = 0; i < transform.childCount; i++)
        {
            var resource = transform.GetChild(i).GetComponent<DestroyableResource>();
            _resources.Add(resource);
            resource.Items = _pickupItemsPool;
        }
    }
}
