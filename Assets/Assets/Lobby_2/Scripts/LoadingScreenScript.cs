using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenScript : MonoBehaviour
{

    public GameObject LoadingScreen;
    public string scenename;

    void Awake()
    {
        LoadingScreen.SetActive(false);
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);

        LoadingScreen.SetActive(true);

        yield return null;
    }
}