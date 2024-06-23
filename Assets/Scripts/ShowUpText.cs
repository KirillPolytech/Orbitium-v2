using UnityEngine;
using System.Collections;
using TMPro;

public class ShowUpText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] float Speed = 0.15f;
    private string _story = "��� ����������� ���� ������� � ����� �� ��������� �������. ����� ������ ����� ��������� ����� �������, �� ����������� ���������� ����� ������ ��-�� �� �������������...";
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
