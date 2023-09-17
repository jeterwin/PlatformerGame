using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnDeath : MonoBehaviour
{
    [SerializeField] private GameObject LoadingScreen;
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
        if(SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings) 
        {
            MainMenu();
            return;
        }
        //Bugged because Untiy lol?
        //Debug.Log(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).name);
        StartCoroutine(LoadScene("Level" + (SceneManager.GetActiveScene().buildIndex + 1)));
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
