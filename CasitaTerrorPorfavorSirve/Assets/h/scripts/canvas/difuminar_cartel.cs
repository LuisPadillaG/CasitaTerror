
using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class difuminar_cartel : MonoBehaviour
{
    //aparece no aparce
    [SerializeField] GameObject click_interativo;

    //Apararce
    //GameObject imagen;

    //Difumina
    Image imagen_letrero;
    Color color_imagen;
    bool aparecer;

    void Start()
    {
        ComponentesyValores();
    }

    void Update()
    {
        Difuminar_Imagen();
    }
    // --------- --------- //
    void ComponentesyValores()
    {
        //cartel difuminar
        imagen_letrero = click_interativo.GetComponent<Image>();
        color_imagen = imagen_letrero.color;


        aparecer = false;
        //desaparezca - color
        color_imagen.a = 0;
        imagen_letrero.color = color_imagen;
    }

    // ---------Funciones --------- //
    void Difuminar_Imagen()
    {
        //limitaciones
        if (aparecer)
            color_imagen.a += Time.deltaTime * 2;
        else
            color_imagen.a -= Time.deltaTime * 2;

        if (color_imagen.a > 1)
            color_imagen.a = 1;

        if (color_imagen.a < 0)
            color_imagen.a = 0;

        imagen_letrero.color = color_imagen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            click_interativo.SetActive(true);
            aparecer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            aparecer = false;
        }
    }
}


