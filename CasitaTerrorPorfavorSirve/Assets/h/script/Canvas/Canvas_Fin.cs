
using UnityEngine;

public class FundidoFinal : MonoBehaviour
{
    public CanvasGroup grupoCanvas;
    public AudioSource musica;

    public float duracion = 2f;

    float tiempo = 0f;
    bool iniciar = false;

    void Start()
    {
        grupoCanvas.alpha = 0f;
    }

    void Update()
    {
        Fundido();
    }

    void Fundido()
    {
        if (iniciar)
        {
            tiempo += Time.deltaTime;
            grupoCanvas.alpha = Mathf.Clamp01(tiempo / duracion);

            if (tiempo >= duracion)
            {
                grupoCanvas.alpha = 1f;
                iniciar = false;

                // Mutear la música al terminar el fundido
                if (musica != null)
                {
                    musica.mute = true;
                }
            }
        }
    }

    public void Iniciar_Fundido()
    {
        tiempo = 0f;
        iniciar = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Iniciar_Fundido();
        }
    }
}
