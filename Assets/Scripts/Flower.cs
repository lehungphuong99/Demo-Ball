using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Flower : MonoBehaviour
{
    [SerializeField] UnityEvent _collision;
    [SerializeField] string _ScenceName;

    void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            ReleaseDiamonds();
            Debug.Log("ok");
            StartCoroutine(LoadNewScence());
        }
    }
   
    void ReleaseDiamonds()
    {
        _collision?.Invoke();
        
    }

    IEnumerator LoadNewScence()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(_ScenceName);
    }
}
