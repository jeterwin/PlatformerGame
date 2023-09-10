using UnityEngine;
using UnityEngine.UI;

public class LevelHolder : MonoBehaviour
{
    public string LevelName;

    public Image LevelImage;

    public void SelectLevel()
    {
        LevelLoader.Instance.LoadingFunction(LevelName);
    }
}
