using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider ProgressSlider;
    [SerializeField] private Button StartButton;

    private AsyncOperation _operation;

    private void Awake()
    {
        StartButton.gameObject.SetActive(false);
        ProgressSlider.value = 0;
    }

    public void StartLoading()
    {
        _operation = SceneManager.LoadSceneAsync(36);
        _operation.allowSceneActivation = false;

        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        if (!_operation.isDone)
        {
            Debug.Log(ProgressSlider.value);
            ProgressSlider.value = _operation.progress;
            yield return null;
        }

        StartButton.gameObject.SetActive(true);
    }
}