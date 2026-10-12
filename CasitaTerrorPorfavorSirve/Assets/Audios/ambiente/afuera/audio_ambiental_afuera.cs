using UnityEngine;

public class audio_ambiental_afuera : MonoBehaviour
{
    public AudioSource audioAmbiental;
    bool jugador_Dentro;

    void Start()
    {
        Componentes();
        Valores();
    }

    void Update()
    {
        volume();
    }

    void Componentes()
    {
        audioAmbiental.volume = 0.12f;
        audioAmbiental.Stop();
    }

    void Valores()
    {
        jugador_Dentro = false;
    }

    void volume()
    {
        if (jugador_Dentro)//al entrar
        {
            audioAmbiental.volume += 0.05f * Time.deltaTime;

            if (audioAmbiental.volume > 0.5f)
                audioAmbiental.volume = 0.5f;

        }
        else//afuera
        {
            audioAmbiental.volume -= 0.1f * Time.deltaTime;

            if (audioAmbiental.volume < 0f)
                audioAmbiental.volume = 0f;

            if (audioAmbiental.volume == 0f)
                audioAmbiental.Stop();
        }


    }


    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugador_Dentro = true;
            audioAmbiental.volume = 0.12f;
            audioAmbiental.Play();
        }
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {
            jugador_Dentro = false;
        }
    }
}
