using UnityEngine;

public class foco_sala : MonoBehaviour
{
    //focos
    public Light[] focos;
    //public Light[] focos_tele;//tiene las mismas luces que foco
    bool subiendo1 = false;

    //audio fx
    public AudioSource bocinas;
    public AudioClip efecto; // efecto
    bool audioReproducido = false;

    public AudioClip sonido_estatico;  //sonido estatido
    bool jugadorDentro = false;//cuando este afuera del rango

    void Start()
    {
        Componentes_Valores();
    }
    void Update()
    {
        televisor();
        audioEstatica_volumen();
    }

    void Componentes_Valores()
    {
        focos = GetComponentsInChildren<Light>();

        for (int i = 0; i < focos.Length; i++)//apagar todo los focos
        { 
            focos[i].enabled = false;
        }
    }


    /* ----- FUNCIONES  ------- */

    void prendido(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;

            // Encender los focos
            for (int i = 0; i < focos.Length; i++)
            {
                focos[i].enabled = true;
            }

            

            // estática
            if (!bocinas.isPlaying)
            {
                audioEstatica();
            }
        }
        // efecto una sola vez
        if (!audioReproducido)
        {
            audio();
            audioReproducido = true;
        }
    }

    //-------------- Tele sube y baja luz

    void televisor()
    {
        if (subiendo1 == false)
        {
            focos[2].intensity -= Time.deltaTime * 0.2f;//d 0.84
            focos[3].intensity -= Time.deltaTime * 11.44f * 0.2f; //d 9.61   [9.61 / 0.84 = 11.44]

            if (focos[2].intensity <= 0.16f)
            {
                focos[2].intensity = 0.16f;
                focos[3].intensity = 1.82f;
                subiendo1 = true;
            }
        }
        else
        {
            focos[2].intensity += Time.deltaTime * 0.2f;
            focos[3].intensity += Time.deltaTime * 11.44f * 0.2f;

            if (focos[2].intensity >= 1f)
            {
                focos[2].intensity = 1f;
                focos[3].intensity = 11.43f;
                subiendo1 = false;
            }
        }//0.84
        
    }

    //-------------- Audio solo una vez
    void audio()
    {
        bocinas.PlayOneShot(efecto);
    }


    //-------------- Audio de estatica
    void audioEstatica()
    {
        bocinas.clip = sonido_estatico;
        bocinas.loop = true;
        bocinas.volume = 0f;
        bocinas.Play();
    }
        
    void audioEstatica_volumen()//adentro y afuera audio
    {

        if (jugadorDentro) // Dentro
        {
            bocinas.volume += 0.5f * Time.deltaTime;

            if (bocinas.volume > 0.5f)
                bocinas.volume = 0.5f;
        }
        else // Fuera
        {
            bocinas.volume -= 0.1f * Time.deltaTime;

            if (bocinas.volume < 0f)
                bocinas.volume = 0f;

            if (bocinas.volume == 0f && bocinas.isPlaying)
                bocinas.Stop();
        }
    }

    void audioEstatica_apagado(Collider other)//este solo apaga
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
        }
    }

    /*--------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        prendido(other);
    }
    private void OnTriggerExit(Collider other)
    {
        audioEstatica_apagado(other);
    }






}
