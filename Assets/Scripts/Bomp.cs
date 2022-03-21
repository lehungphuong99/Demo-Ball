using System.Collections;
using UnityEngine;

public class Bomp : MonoBehaviour
{
    [SerializeField] Sprite _Exploded;
    [SerializeField] Sprite _UnPressed;
    [SerializeField] float _bounceVelocity = 3f;

    SpriteRenderer _spriteRenderer;
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _UnPressed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        var ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            _spriteRenderer.sprite = _Exploded;
            
            var particleSystem = GetComponent<ParticleSystem>();
            particleSystem.Play();
            
            var Ballobj = ball.GetComponent<Rigidbody2D>();
            if (Ballobj == null)
            {
                Ballobj.velocity = new Vector2(Ballobj.velocity.x, _bounceVelocity);
            }
            
            StartCoroutine(LoadAfterDelay(ball));

            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator LoadAfterDelay(Ball ball)
    {
        Debug.Log("ready to blow!");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("exploded");
        ball.ResetToStart(); // more invoke 
        
    }
}
