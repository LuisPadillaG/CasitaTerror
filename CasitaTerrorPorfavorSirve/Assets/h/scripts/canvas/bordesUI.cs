using UnityEngine;

public class bordesUI : MonoBehaviour
{
    Camera mainCamera;
    bool aparecer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform.position + mainCamera.transform.forward);//rotacion
        }
    }
}
