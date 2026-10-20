using UnityEngine;

public class PuertaRoja_Telleva : MonoBehaviour
{
    private Vector3 posicionUbicacionPuertaRoja;
    GameObject player;

    /*
    void Start()
    {

        GameObject puertaRoja = GameObject.Find("puertaRoja");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (puertaRoja != null)
        {posicionUbicacionPuertaRoja = puertaRoja.transform.position;}
        else
        { Debug.LogError("No se encontró el objeto 'puertaRoja' en la escena. Revisa el nombre."); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("teleport_puertaRoja"))
        {
            other.transform.position = posicionUbicacionPuertaRoja;
            player = puertaRoja.transform.position;
        }
        Debug.Log("¡Teletransporte exitoso!");
        }
    }
    */
}