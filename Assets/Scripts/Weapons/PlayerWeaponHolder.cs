using ObjectPool;
using UnityEngine;

public class PlayerWeaponHolder : MonoBehaviour
{
    [SerializeField] private MeleeWeapon _currentWeapon;
    [SerializeField] private RangeWeapon _rangeWeapon;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private SingleAnimationPlayer _bulletHitEffect;
    private float _shootingPixelTimer;
    private bool _shooting;
    private BasePool<Bullet> _bullets;
    private BasePool<SingleAnimationPlayer> _bulletHitEffects;
    private void Start()
    {
        _bullets = new BasePool<Bullet>(_bulletPrefab.gameObject, 20, "Bullets");
        _bulletHitEffects = new BasePool<SingleAnimationPlayer>(_bulletHitEffect.gameObject, 20, "BulletHitEffects");
        _rangeWeapon.Init(this);
    }
    public void HandleRotation(Vector2 mousePosition)
    {
        var rotationAngle = (Vector3)mousePosition - transform.position;
        float angle = Mathf.Atan2(rotationAngle.y, rotationAngle.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3 (0f, 0f, angle);
    }
    private void Update()
    {
        _shootingPixelTimer += Time.deltaTime;
        if (_shooting)
        {
            Shoot();
        }
    }
    
    public void StartShooting()
    {
        _shooting = true;
    }
    public void StopShooting()
    {
        _shooting = false;
    }
    public void MeleeAttack()
    {
        _currentWeapon.gameObject.SetActive(true);
        _currentWeapon.Attack();
    }
    public void SpawnHitEffect(Vector2 at)
    {
        var hitEffect = _bulletHitEffects.Get();
        hitEffect.gameObject.SetActive(true);
        hitEffect.transform.position = at;
    }
    private void Shoot()
    {
        if (_shootingPixelTimer < _rangeWeapon.ShootingDelay)
            return;
        _shootingPixelTimer = 0;
        var bullet = _bullets.Get();
        bullet.gameObject.SetActive(true);
        _rangeWeapon.Shoot(bullet);
    }
}
