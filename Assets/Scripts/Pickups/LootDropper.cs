using ObjectPool;
using UnityEngine;

public class LootDropper : MonoBehaviour
{
    [SerializeField] private int _minItemsToDrop = 1, _maxItemsToDrop = 5;
    [SerializeField] private float _xOffset = 1f, _yOffset = 1f;
    [SerializeField] private PickupItem _pickupPrefab;
    [SerializeField] private PickupItemSO _itemToDrop;
    public void DropLoot(BasePool<PickupItem> items)
    {
        //TODO: Вместо Instantiate использовать Pool
        var itemsToDrop = Random.Range(_minItemsToDrop, _maxItemsToDrop);
        for (int i = 0; i < itemsToDrop; i++)
        {
            var pickup = items.Get();
            pickup.gameObject.SetActive(true);
            pickup.transform.position = transform.position;
            pickup.Init(_itemToDrop);

            var targetPointX = Random.Range(-_xOffset, _xOffset);
            var targetPointY = Random.Range(-_yOffset, _yOffset);
            pickup.AnimateDrop(transform.position + new Vector3(targetPointX, targetPointY, 0));
        }
    }
}
