
using UnityEngine;

public class canvas_candado : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "candado")
        {
            Debug.Log("me electrocutaste pedrito");

            Rigidbody rogo = other.GetComponent<Rigidbody>();
            rogo.constraints = RigidbodyConstraints.None;

            Destroy(other.gameObject, 1);

            Invoke("DesactivarPuerta", 1);

            Debug.Log("Lo logramos");
        }
    }

   
    void DesactivarPuerta() // La puerta se desactiva
    {
        GameObject door_salida = GameObject.Find("door_salida");

        if (door_salida != null)
        {
            door_salida.SetActive(false);
        }
    }
}
