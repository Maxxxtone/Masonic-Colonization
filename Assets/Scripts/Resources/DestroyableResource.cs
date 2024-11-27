using DG.Tweening;
using ObjectPool;
using System;
using UnityEngine;

public class DestroyableResource : MonoBehaviour, IDamagable
{
    public BasePool<PickupItem> Items;
    [SerializeField] private int _maxHP = 50;
    [SerializeField] private LootDropper _lootPoint;
    private int _hp;
    private void Start()
    {
        _hp = _maxHP;
    }
    public void TakeDamage(int damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, _maxHP);
        transform.DOShakePosition(.1f, .25f, 10);
        if (_hp == 0)
        {
            _lootPoint.DropLoot(Items);
            Destroy(gameObject);
        }
    }

}
