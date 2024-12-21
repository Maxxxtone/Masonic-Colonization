using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _flySpeed = 8f;
    private Rigidbody2D _rb;
    private Weapon _weaponPresets;
    public void Shoot(Weapon weapon, Vector2 direction)
    {
        _rb ??= GetComponent<Rigidbody2D>();
        _rb.AddForce(direction * _flySpeed, ForceMode2D.Impulse);
        _weaponPresets = weapon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_weaponPresets.Damage);
        }
        _weaponPresets.PlayerWeaponHolder.SpawnHitEffect(transform.position);
        gameObject.SetActive(false);
    }
}
