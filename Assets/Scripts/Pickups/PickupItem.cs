using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PickupItem : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f, _dropAnimationTime = 1f;
    private PickupItemSO _item;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    public PickupItemSO Item => _item;
    public void Init(PickupItemSO item)
    {
        _item = item;
        _spriteRenderer ??= GetComponent<SpriteRenderer>();
        _rb ??= GetComponent<Rigidbody2D>();
        _spriteRenderer.sprite = _item.Icon;
        //animation
    }
    public void AnimateDrop(Vector2 targetPosition)
    {
        _rb.DOJump(targetPosition, _jumpForce, 3, _dropAnimationTime);
    }
}
