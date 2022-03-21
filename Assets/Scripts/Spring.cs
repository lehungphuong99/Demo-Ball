using UnityEngine;
public class Spring : MonoBehaviour
{
    
    [SerializeField] float _bounceVelocity = 10f;
    [SerializeField] Sprite _downSprite;
    
    SpriteRenderer _spriteRenderer;
    Sprite _upSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _upSprite = _spriteRenderer.sprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        var Ball = collision.collider.GetComponent<Ball>();
        if (Ball != null)
        {
            var Ballobj = Ball.GetComponent<Rigidbody2D>();
            if (Ballobj != null)
            {
                Ballobj.velocity = new Vector2(Ballobj.velocity.x, _bounceVelocity);
                _spriteRenderer.sprite = _downSprite;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        var Ball = collision.collider.GetComponent<Ball>();
        if (Ball != null)
        {
            _spriteRenderer.sprite = _upSprite;
        }
    }
}
