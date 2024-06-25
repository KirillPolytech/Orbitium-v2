using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    private const float Accuracy = 0.001f;
    
    private RawImage _image;
    private bool _isEnable;
    
    private void Awake()
    {
        _image = transform.GetComponentInChildren<RawImage>();
        
        _image.enabled = true;
    }

    public void Enable()
    {
        _isEnable = true;
        StartCoroutine(HandleImageAlpha());
    }

    public void Disable()
    {
        _isEnable = false;
        StartCoroutine(HandleImageAlpha());
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    private IEnumerator HandleImageAlpha()
    {
        yield return new WaitForSeconds(0.5f);
        
        int sign = Convert.ToInt32(_isEnable) == 0 ? -1 : 1;
        do
        {
            _image.color += sign * new Color(0, 0, 0, Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        } while (_image.color.a is > Accuracy and < 1 - Accuracy);
    }
}