using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;

    public GameObject LoadingScreen;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadingFunction(string LevelName)
    {
        StartCoroutine(StartLoading(LevelName));
    }

    IEnumerator StartLoading(string LevelName)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelName);
        LoadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            yield return null;
        }

    }
}
