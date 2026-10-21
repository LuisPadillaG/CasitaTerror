using UnityEngine;

public class luz_prendido_apagadoDefinitivamentearreglo : MonoBehaviour
{
    // Luces que queremos apagar
    public Light[] focos;

    void Start()
    {
        Componentes_Valores();
    }

    void Componentes_Valores()
    {
        for (int i = 0; i < focos.Length; i++)//encendidas
        {
            if (focos[i] != null)
            focos[i].enabled = true;
        }
    }

    void prendido(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < focos.Length; i++)  // Apagar 
            {
                if (focos[i] != null)
                focos[i].enabled = false; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        prendido(other);
    }
}
