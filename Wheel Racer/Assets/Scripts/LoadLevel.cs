using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Slider loadingBar;

    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            print(progress);

            loadingBar.value = progress;

            yield return null;
        }
    }
}
