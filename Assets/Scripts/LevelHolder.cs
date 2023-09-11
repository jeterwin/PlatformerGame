using UnityEngine;
using UnityEngine.UI;

public class LevelHolder : MonoBehaviour
{
    public int LevelID;

    public Image LevelImage;

    public void SelectLevel()
    {
        LevelGenerator.Instance.StartCoroutine(LevelGenerator.Instance.StartLoading(LevelID));
    }
}
