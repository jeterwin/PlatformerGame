using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public LevelLoader Instance;

    public GameObject LoadingScreen;

    public TextMeshProUGUI LoadingText;

    public string NextLevel;

    private void Awake()
    {
        Instance = this;
    }
    public void LoadingFunction()
    {
        StartCoroutine(StartLoading(NextLevel));
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
