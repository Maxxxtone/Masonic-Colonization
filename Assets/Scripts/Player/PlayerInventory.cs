using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ResourcesDatabase _resourcesDatabase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PickupItem item))
        {
            _resourcesDatabase.Add(item.Item);
            item.gameObject.SetActive(false);
        }
    }
}
