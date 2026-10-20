using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class luz_prendido_apagadoDefinitivamente : MonoBehaviour
{

    //focos
    public Light[] focos;
    bool jugadorDentro = true;

    void Start()
    {
        Componentes_Valores();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void Componentes_Valores()
    {
        focos = GetComponentsInChildren<Light>();

        for (int i = 0; i < focos.Length; i++)//apagar todo los focos
        {
            focos[i].enabled = true;
        }
    }


    void prendido(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            for (int i = 0; i < focos.Length; i++)// Encender los focos
            {
                focos[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        prendido(other);
    }









}



