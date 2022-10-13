using UnityEngine;
using UnityEngine.UI;

public class CounterProgress : MonoBehaviour
{
    private Text _text;
    private int _score;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void AddScore()
    {
        _score += 1;
        _text.text = _score.ToString();
    }
}
