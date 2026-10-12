using UnityEngine;

public class foco_sala : MonoBehaviour
{
    //focos
    public Light[] focos;
    //public Light[] focos_tele;//tiene las mismas luces que foco
    bool subiendo1 = false;

    //audio
    public AudioSource bocinas;
    public AudioClip efecto;
    bool audioReproducido = false;
    void Start()
    {
        Componentes_Valores();
    }
    void Update()
    {
        televisor();
    }

    void Componentes_Valores()
    {
        focos = GetComponentsInChildren<Light>();

        for (int i = 0; i < focos.Length; i++)//apagar todo los focos
        { 
            focos[i].enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        prendido(other);
    }


    void prendido(Collider other)//funcion (audio())
    {
        //focos
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < focos.Length; i++)//prender
            {
                focos[i].enabled = true;//focos_tele[i].enabled = true;
                
            }
        }

        //audio
        if (audioReproducido == false)
        {
            audio();
            audioReproducido = true;
        }

    }

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


    void audio()
    {
        bocinas.PlayOneShot(efecto);
    }

}   
