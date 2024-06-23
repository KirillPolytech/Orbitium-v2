using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    private RawImage _image;
    private void Awake()
    {
        _image = transform.GetChild(0).GetComponent<RawImage>();
    }

    private void Start()
    {
        _image.enabled = true;
    }

    private void Update()
    {
        _image.color -= new Color(0, 0, 0, Time.deltaTime);
    }
}
