using Cinemachine;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;

    [SerializeField] private Camera SecondaryCamera;

    private void Update()
    {
        SecondaryCamera.orthographicSize = MainCamera.orthographicSize;
    }
}
