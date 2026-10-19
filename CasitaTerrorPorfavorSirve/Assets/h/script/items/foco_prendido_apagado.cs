
using UnityEngine;  

public class foco_prendido_apagado : MonoBehaviour
{
    //Focos
    Light[] focos; //Light foco;
    bool prendido;
    float temporizador;

    // Audio de los focos
    public AudioSource audio_luz;
    bool jugadorDentro;

    void Start()
    {
        Componentes_Valores();
    }

    void Update()
    {
        switchh();
        focos_audio();
    }


    void Componentes_Valores() 
    {
        focos = GetComponentsInChildren<Light>();//foco = GetComponent<Light>();
        prendido = true;
        temporizador = Random.Range(0.1f, 6f);

        // Audio de los focos
        audio_luz.volume = 0.302f;
        audio_luz.loop = true;
        audio_luz.Stop();
        jugadorDentro = false;

    }


    void switchh()//prende y apaga con random
    {
        temporizador -= Time.deltaTime;

        if (temporizador <= 0)//cambiar el estado.
        {
            prendido = !prendido;//false

            for (int i = 0; i < focos.Length; i++)
            focos[i].enabled = prendido;  //focos.enabled = prendido;//prendido

            temporizador = Random.Range(0.1f, 6f);
        }

    }

    void focos_audio()
    {

        if (jugadorDentro && prendido)
        {
            if (!audio_luz.isPlaying)
            {
                audio_luz.Play();
            }
        }
        else
        {
            if (audio_luz.isPlaying)
            {
                audio_luz.Stop();
            }
        }
        /*
        if (jugadorDentro && prendido)// jugador dentro y sonido
        {
            if (!audio_luz.isPlaying)
            { audio_luz.Play();}

            audio_luz.volume += 0.5f * Time.deltaTime;

            if (audio_luz.volume >= 0.5f)
            { audio_luz.volume = 0.5f; }
        }
     
        else// jugador fuera
        {
            audio_luz.volume -= 0.5f * Time.deltaTime;

            if (audio_luz.volume <= 0f)
            { 
                audio_luz.volume = 0f;

                if (audio_luz.isPlaying)
                { audio_luz.Stop();}
            }
        }
        */
    }

    // Cuando entra al área
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
        }
    }

    // Cuando sale del área
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }


}
