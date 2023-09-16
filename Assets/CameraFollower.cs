using Cinemachine;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Camera MainCamera;

    [SerializeField] Camera SecondaryCamera;

    private void Update()
    {
        SecondaryCamera.orthographicSize = MainCamera.orthographicSize;
    }
}
