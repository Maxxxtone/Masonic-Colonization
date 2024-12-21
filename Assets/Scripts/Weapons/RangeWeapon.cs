using Cinemachine;
using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private CinemachineImpulseSource _impulse;
    [SerializeField] private float _shootingDelay = .05f;
    private PlayerWeaponHolder _weaponHolder;
    public float ShootingDelay => _shootingDelay;
    public void Shoot(Bullet bullet)
    {
        bullet.transform.position = _firePoint.position;
        bullet.Shoot(this, _firePoint.right);
        _impulse.GenerateImpulse();
        AnimateShot();
    }
}
