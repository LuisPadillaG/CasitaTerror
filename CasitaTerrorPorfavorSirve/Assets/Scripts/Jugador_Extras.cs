using UnityEngine;

public class Jugador_Extras : MonoBehaviour
{
    new Vector3 posicionJugador, ultimaPuertaCorrecta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionJugador = this.transform.position;
        ultimaPuertaCorrecta = GameObject.FindWithTag("puerta_correcta").transform.position;
        Debug.Log(ultimaPuertaCorrecta);
        Debug.Log(posicionJugador);
    }
    // Update is called once per frame
    void Update()
    {
        posicionJugador = this.transform.position;
        Debug.Log(posicionJugador);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puerta_correcta")
        {
            ultimaPuertaCorrecta = other.transform.position;
        }
        if(other.gameObject.tag == "puerta_incorrecta")
        {
            Vector3 posicionFinal = other.transform.position; 
            Vector3 diferencia = posicionFinal - posicionJugador;
            this.transform.position = ultimaPuertaCorrecta - diferencia;
            Debug.Log("Si he entrado al trigger de estos");
        }
        
    }
}
