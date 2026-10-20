
using UnityEngine;

public class PuertaRoja_Telleva : MonoBehaviour
{
    Vector3 posicionUbicacionPuertaRoja;

    void Start()
    {
        GameObject puertaRoja = GameObject.Find("Puerta_Roja_final");

        if (puertaRoja != null)
        {
            posicionUbicacionPuertaRoja = puertaRoja.transform.position;
        }
        else
        {
            Debug.LogError("No se encontró la puerta roja.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = posicionUbicacionPuertaRoja;

            Debug.Log("¡Teletransporte exitoso!");
        }
    }
}
