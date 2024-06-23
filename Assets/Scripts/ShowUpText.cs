using UnityEngine;
using System.Collections;
using TMPro;

public class ShowUpText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] float Speed = 0.15f;
    private string _story = "Две космические расы сошлись в битве на просторах космоса. Война унесла жизни множества живых существ, но закончилась поражением обеих сторон из-за их безрассудства...";
    void Start()
    {
        StartCoroutine("ShowText", _story);
    }
    IEnumerator ShowText()
    {
        int i = 0;
        while (i <= _story.Length)
        {
            _text.text = _story.Substring(0, i);
            i++;

            yield return new WaitForSeconds(Speed);
        }
    }
}
