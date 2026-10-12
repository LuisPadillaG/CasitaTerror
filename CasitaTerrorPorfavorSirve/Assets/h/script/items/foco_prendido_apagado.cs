using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class foco_prendido_apagado : MonoBehaviour
{
    Light[] focos; //Light foco;
    bool prendido;
    float temporizador;

    void Start()
    {
        Componentes_Valores();
    }

    void Update()
    {
        switchh();
    }


    void Componentes_Valores() 
    {
        focos = GetComponentsInChildren<Light>();//foco = GetComponent<Light>();
        prendido = true;
        temporizador = Random.Range(0.1f, 6f);
    }

    void switchh()
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

}
