using UnityEngine.InputSystem;
using UnityEngine;

public class InputActionManager : MonoBehaviour
{
    [SerializeField] InputActionAsset asset;

    private void Awake()
    {
        asset.Enable();
    }

    private void OnDestroy()
    {
        asset.Disable();
    }
}
