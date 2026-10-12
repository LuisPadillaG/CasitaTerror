using UnityEngine;

public class ventilador : MonoBehaviour
{
    [Range(-360f, 360f)]
    public float spiner = 100f;

    void Update()
    {
        transform.localRotation *= Quaternion.Euler(0f, 0f, spiner * Time.deltaTime);
    }

}
