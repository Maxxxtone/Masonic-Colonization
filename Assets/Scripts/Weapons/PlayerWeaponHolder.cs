using UnityEngine;

public class PlayerWeaponHolder : MonoBehaviour
{
    [SerializeField] private MeleeWeapon _currentWeapon;
    public void MeleeAttack()
    {
        _currentWeapon.gameObject.SetActive(true);
        _currentWeapon.Attack();
    }
}
