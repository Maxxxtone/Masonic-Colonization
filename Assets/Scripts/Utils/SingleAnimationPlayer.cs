using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SingleAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Sprite[] _frames;
    [SerializeField] private float _frameRate = 12;
    [SerializeField] private bool _looping = false;
    private SpriteRenderer _spriteRenderer;
    private int _currentFrame = 0;
    private float _pixelTimer;
    private void OnEnable()
    {
        _spriteRenderer ??= GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(_pixelTimer > 1 / _frameRate)
        {
            _currentFrame++;
            if (_currentFrame >= _frames.Length - 1)
            {
                if(_looping ) 
                    _currentFrame = 0;
                else
                    gameObject.SetActive(false);
            }
            _spriteRenderer.sprite = _frames[_currentFrame];
            _pixelTimer = 0;
        }
        _pixelTimer += Time.deltaTime;
    }
}
