using UnityEngine;

public class Ball : MonoBehaviour
{
    public ParticleSystem Dust;
    [SerializeField] AudioSource _landedAudioSource;
   
    [SerializeField] float _speed = 5f;
    [SerializeField] int _jumpForce = 7;

    Rigidbody2D _rigidbody2D;
    bool _isground;
    float _offset = 0.7f;
    int _jumpRemaing;
    int _maxJumps = 2;
    Vector3 _startPosition;

    void Awake()
    {
        _rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        _jumpRemaing = _maxJumps;
        _startPosition = transform.position;
    }

    void Update()
    {
       MoveHorizontal();

       Jump();
    }

    void OnCollisionEnter2D(Collision2D collision)  // define ball is on the ground
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("ground"));
        if (hit)
        {
            _isground = true;
            CreateDust();
            _landedAudioSource.Play();
        }
        
        Debug.Log(_jumpRemaing);
        if (_isground)
            _jumpRemaing = _maxJumps;
    }

    public void Jump()
    {
        var jump = Input.GetButtonDown("Jump");
        if (jump && _jumpRemaing > 0)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
            if (_isground)
            {
                CreateDust();
            }
            GetComponent<AudioSource>().Play();
            _jumpRemaing--;
        }
    }

    public void jump()
    {
        var jump = Input.GetButtonDown("Jump");
        if (jump)
           _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }
    internal void MoveHorizontal()
    {
        var horizontal = SimpleInput.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            _rigidbody2D.velocity = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);
        }
    }

    void CreateDust()
    {
        var dustPos = transform.position;
        dustPos.y -= _offset;
        Dust.transform.position = dustPos;
        Dust.Play();
    }
    internal void ResetToStart()
    {
        _rigidbody2D.position = _startPosition;
    }
}
