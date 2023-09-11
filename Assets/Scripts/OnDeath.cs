using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnDeath : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;
    public void ResetLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }
    public void MainMenu()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }
    public void NextLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name));
    }
    IEnumerator LoadScene(string LevelName)
    {
        AsyncOperation AsyncOperation = SceneManager.LoadSceneAsync(LevelName);
        LoadingScreen.SetActive(true);
        while(!AsyncOperation.isDone)
        {

            yield return null;
        }

        yield return null;
    }
}
