using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHp = 25;
    private float _hp;
    public float Hp
    {
        get => _hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, _maxHp);
        }
    }
    private void Start()
    {
        Hp = _maxHp;
    }
    public void TakeDamage(float amount)
    {
        Hp -= amount;
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
