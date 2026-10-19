
using UnityEngine;

public class audio_ambiental_afuera : MonoBehaviour
{
    public AudioSource audioAmbiental;
    bool jugador_Dentro;

    public float max_audio = 0.5f;//maximo
    public float min_audio = 0.1f;//bajo 

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
        audioAmbiental.volume = 0f;
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
            if (!audioAmbiental.isPlaying)
                audioAmbiental.Play();

            audioAmbiental.volume += min_audio * Time.deltaTime;

            if (audioAmbiental.volume > max_audio)
                audioAmbiental.volume = max_audio;

        }
        else//afuera
        {
            audioAmbiental.volume -= min_audio * Time.deltaTime;

            if (audioAmbiental.volume < 0f)
                audioAmbiental.volume = 0f;

            if (audioAmbiental.volume == 0f && audioAmbiental.isPlaying)
                audioAmbiental.Stop();
        }
    }


    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Player"))
        { jugador_Dentro = true;}
    }

    void OnTriggerExit(Collider otro)
    {
        if (otro.CompareTag("Player"))
        {jugador_Dentro = false; }
    }
}
