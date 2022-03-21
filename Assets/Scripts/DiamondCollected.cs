using UnityEngine.UI;
using UnityEngine;

public class DiamondCollected : MonoBehaviour
{
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = Boxes._DiamondCollected.ToString();
    }
}
