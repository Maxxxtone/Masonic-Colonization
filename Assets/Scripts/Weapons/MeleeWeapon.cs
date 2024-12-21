using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource _impulse;
    [SerializeField] private int _damage = 10;
    public void Attack()
    {
        Sequence attackAnimation = DOTween.Sequence();
        attackAnimation.Append(transform.parent.DOLocalRotate(new Vector3(0, 0, 50), .1f, RotateMode.LocalAxisAdd)).
            Append(transform.parent.DOLocalRotate(new Vector3(0, 0, -280), .15f, RotateMode.LocalAxisAdd)).
            Append(transform.parent.DOLocalRotate(new Vector3(0, 0, 0), .1f));
        attackAnimation.Play();
        StartCoroutine(DisableWeaponAfterAttack());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);
            _impulse.GenerateImpulse();
        }
    }
    private IEnumerator DisableWeaponAfterAttack()
    {
        yield return new WaitForSeconds(.4f);
        transform.localEulerAngles = Vector3.zero;
        gameObject.SetActive(false);
    }
}
