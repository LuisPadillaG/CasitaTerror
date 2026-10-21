
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class TeMAteChePta : MonoBehaviour
{
    Vector3 posicionPlayer;
    Vector3 posicionEnemigo;

    GameObject jugador;
    GameObject enemigo;

    public GameObject InstaKill;
    public GameObject canvasMuerte;
    public GameObject modeloVillano;
    public AudioSource grito;

    Image imagenRoja;
    Color colorOriginal;

    bool reiniciando = false;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        enemigo = GameObject.FindGameObjectWithTag("Enemigo");

        if (jugador != null)
        {
            posicionPlayer = jugador.transform.position;
        }

        if (enemigo != null)
        {
            posicionEnemigo = enemigo.transform.position;
        }

        if (canvasMuerte != null && canvasMuerte.transform.childCount > 1)
        {
            imagenRoja = canvasMuerte.transform.GetChild(1).GetComponent<Image>();

            if (imagenRoja != null)
            {
                colorOriginal = imagenRoja.color;
            }
        }

        if (InstaKill != null)
        {
            InstaKill.SetActive(false);
        }

        if (canvasMuerte != null)
        {
            canvasMuerte.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !reiniciando)
        {
            StartCoroutine(ReiniciarJuego());
        }
    }

    IEnumerator ReiniciarJuego()
    {
        reiniciando = true;

        // Ocultar modelo del villano
        if (modeloVillano != null)
        {
            modeloVillano.SetActive(false);
        }

        // Activar efecto de muerte
        if (InstaKill != null)
        {
            InstaKill.SetActive(true);
        }

        // Activar canvas
        if (canvasMuerte != null)
        {
            canvasMuerte.SetActive(true);
        }

        // Reproducir grito
        if (grito != null)
        {
            grito.Play();
        }

        // Mantener blanco durante el primer cuarto del tiempo total
        if (imagenRoja != null)
        {
            imagenRoja.color = colorOriginal;
        }

        yield return new WaitForSeconds(0.5f);

        // Transicionar de blanco a rojo
        if (imagenRoja != null)
        {
            float tiempo = 0f;
            float duracion = 0.4f;

            while (tiempo < duracion)
            {
                tiempo += Time.deltaTime;

                imagenRoja.color = Color.Lerp(
                    Color.white,
                    Color.red,
                    tiempo / duracion
                );

                yield return null;
            }

            imagenRoja.color = Color.red;
        }

        // Mantener la pantalla roja hasta completar los 2 segundos
        yield return new WaitForSeconds(1.1f);

        // Devolver al jugador a su posición inicial
        if (jugador != null)
        {
            CharacterController controlador =
                jugador.GetComponent<CharacterController>();

            if (controlador != null)
            {
                controlador.enabled = false;
            }

            jugador.transform.position = posicionPlayer;

            if (controlador != null)
            {
                controlador.enabled = true;
            }
        }

        // Devolver al villano a su posición inicial
        if (enemigo != null)
        {
            NavMeshAgent agente = enemigo.GetComponent<NavMeshAgent>();

            if (agente != null && agente.enabled && agente.isOnNavMesh)
            {
                agente.ResetPath();
                agente.Warp(posicionEnemigo);
            }
            else
            {
                enemigo.transform.position = posicionEnemigo;
            }
        }

        // Restaurar color original
        if (imagenRoja != null)
        {
            imagenRoja.color = colorOriginal;
        }

        // Desactivar efectos de muerte
        if (InstaKill != null)
        {
            InstaKill.SetActive(false);
        }

        if (canvasMuerte != null)
        {
            canvasMuerte.SetActive(false);
        }

        // Mostrar nuevamente al villano
        if (modeloVillano != null)
        {
            modeloVillano.SetActive(true);
        }

        reiniciando = false;
    }
}
