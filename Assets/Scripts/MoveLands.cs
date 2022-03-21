using UnityEngine;

public class MoveLands : MonoBehaviour
{
    Vector2 _startPosition;
    [SerializeField] Vector2 _direction = Vector2.up;
    [SerializeField] float _maxdistance = 3;
    [SerializeField] float _speed = 5;
    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(_direction.normalized * Time.deltaTime * _speed);
        double fly = Vector2.Distance(_startPosition,transform.position);

        if (fly > _maxdistance)
        {
            transform.position = _startPosition + (_direction.normalized * _maxdistance);
            _direction *= -1;
        }
    }
}
