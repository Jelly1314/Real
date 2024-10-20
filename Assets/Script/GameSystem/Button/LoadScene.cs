using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject LoaderUI;
    public Slider progressSlider;

    void Start()
    {
        Time.timeScale = 1f; // Ensure the game is running at normal speed
    }
    void ResumeAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.time > 0f) // If it was paused
            {
                audioSource.UnPause();
            }
        }
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadScene_Coroutine(index));

    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}