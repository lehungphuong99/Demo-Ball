using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform _target;
    
    void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}
