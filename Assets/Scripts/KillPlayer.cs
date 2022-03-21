using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var ball = collider.GetComponent<Ball>();
        if (ball == null)
            return;
        if (ball != null)
        {
            ball.ResetToStart();
        }
    }
}
