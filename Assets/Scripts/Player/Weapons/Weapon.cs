using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private float _offset = .1f, _offsetTime = .05f;
    [SerializeField] private GameObject _light;
    protected PlayerWeaponHolder WeaponHolder;
    public PlayerWeaponHolder PlayerWeaponHolder => WeaponHolder;
    public float Damage => _damage;
    public void Init(PlayerWeaponHolder weaponHolder)
    {
        WeaponHolder = weaponHolder;
    }
    public void AnimateShot()
    {
        transform.DOLocalMoveX(transform.localPosition.x - _offset, _offsetTime).SetLoops(2, LoopType.Yoyo);
        StartCoroutine(ShowLight());
    }
    private IEnumerator ShowLight()
    {
        _light.SetActive(true);
        yield return new WaitForSeconds(_offsetTime);
        _light.SetActive(false);
    }
}
