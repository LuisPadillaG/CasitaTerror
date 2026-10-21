using UnityEngine;

public class ignora_colisonadores : MonoBehaviour
{
    public CharacterController jugador;

    void Start()
    {
        if (jugador == null)
        {
            Debug.LogError(
                "Asigna el Character Controller del jugador.",
                this
            );
            return;
        }

        Collider[] colisiones =
            GetComponentsInChildren<Collider>(true);

        foreach (Collider colision in colisiones)
        {
            // Conservamos los triggers de proximidad.
            if (colision.isTrigger)
                continue;

            // Ignora el choque con el jugador,
            // pero conserva los choques con el escenario.
            Physics.IgnoreCollision(
                jugador,
                colision,
                true
            );
        }
    }
}
