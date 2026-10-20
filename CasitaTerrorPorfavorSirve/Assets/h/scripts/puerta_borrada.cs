using UnityEngine;

public class puerta_borrada : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject, 1);
        }
    }
}
