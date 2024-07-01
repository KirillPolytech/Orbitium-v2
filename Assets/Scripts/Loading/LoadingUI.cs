using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private Slider progressSlider;
    
    private AsyncOperation _operation;
    private Canvas _canvas;
    
    private void OnEnable()
    {
        _canvas = GetComponentInChildren<Canvas>();
        
        SetVisibility(false);
        
        progressSlider.value = 0;
    }

    public void SetVisibility(bool isVisible)
    {
        _canvas.enabled = isVisible;
    }
    
    public void StartLoading(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        _operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        
        while (!_operation.isDone)
        {
            progressSlider.value = _operation.progress;
            yield return null;
        }
    }    
}