
using UnityEngine;

public class IgnorarColisionesJugador : MonoBehaviour
{
    CharacterController CharacterJugador;

    void Start()
    {
        GameObject TagJugador = GameObject.FindGameObjectWithTag("Player");

        if (TagJugador == null)
        {
            Debug.LogWarning("No se encontró el tag Player.");
            return;
        }

        CharacterJugador = TagJugador.GetComponent<CharacterController>();

        if (CharacterJugador == null)
        {
            Debug.LogWarning("Player no tiene CharacterController.");
            return;
        }

        Ignorar_Colisiones();
    }

    void Ignorar_Colisiones()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("SinCollision");

        Debug.Log("Objetos encontrados: " + objetos.Length);

        for (int i = 0; i < objetos.Length; i++)
        {
            Collider[] colisiones = objetos[i].GetComponentsInChildren<Collider>();

            for (int j = 0; j < colisiones.Length; j++)
            {
                Physics.IgnoreCollision(CharacterJugador, colisiones[j], true);

                Debug.Log(
                    colisiones[j].name + " ignorado: " +
                    Physics.GetIgnoreCollision(CharacterJugador, colisiones[j])
                );
            }
        }

        // Comprobar los colliders del objeto palanca
        GameObject objetoPalanca = GameObject.Find("palanca");

        if (objetoPalanca != null)
        {
            Collider[] collidersPalanca =
                objetoPalanca.GetComponents<Collider>();

            for (int i = 0; i < collidersPalanca.Length; i++)
            {
                Debug.Log(
                    collidersPalanca[i].name +
                    " | Ignora jugador: " +
                    Physics.GetIgnoreCollision(
                        CharacterJugador,
                        collidersPalanca[i]
                    )
                );
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto palanca.");
        }
    }
}



/*
CharacterController CharacterJugador;

void Start()
{
    GameObject TagJugador = GameObject.FindGameObjectWithTag("Player");//tag
    CharacterJugador = TagJugador.GetComponent<CharacterController>();//Character
    Ignorar_Colisiones(); 
}


void Ignorar_Colisiones()
{
    if (CharacterJugador == null)
    {
        Debug.LogWarning("CharacterJugador es null.");
        return;
    }

    GameObject[] objetos = GameObject.FindGameObjectsWithTag("SinCollision");

    Debug.Log("Objetos encontrados: " + objetos.Length);

    for (int i = 0; i < objetos.Length; i++)
    {
        Collider[] colisiones = objetos[i].GetComponentsInChildren<Collider>(true);
        Debug.Log("Objeto: " + objetos[i].name +" | Colliders: " + colisiones.Length );

        for (int j = 0; j < colisiones.Length; j++)
        {
            Physics.IgnoreCollision( CharacterJugador,colisiones[j], true);
            Debug.Log( "Ignorando colisión con: " +colisiones[j].name);
        }
    }
}
*/
