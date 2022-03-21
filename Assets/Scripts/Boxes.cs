using UnityEngine;

public class Boxes : MonoBehaviour
{
    public static int _DiamondCollected;

    void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.collider.GetComponent<Ball>();
        if (ball is null)
        {
            return;
        }

        var ballPos = ball.transform.position;
        var boxPos = transform.position;

        if (ballPos.y > boxPos.y)
        {
            if (ballPos.x > boxPos.x) // ball at the right of box
            {
                // box go to left
                transform.rotation = new Quaternion(0, 0, 0.6f, 1);
            }
            else
            {
                // box go to right
                transform.rotation = new Quaternion(0f, 0f, -0.6f, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var Ball = collider.GetComponent<Ball>();
        if (Ball == null)
            return;
        
        gameObject.SetActive(false);
        _DiamondCollected++;
        Debug.Log(_DiamondCollected);
    }
        // var contact = collision.contacts[0];
        // Vector2 normal = contact.normal;
        //
        // if (ball != null && normal.y < -0.9)
        // {
        //     transform.rotation = new Quaternion(0, 0, 0.6f, 1);
        // }
}