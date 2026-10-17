
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class desaparece_cartel : MonoBehaviour
{

    //aparece no aparce
    [SerializeField] GameObject click_interativo;
    [SerializeField] XRGrabInteractable objetoAgarrable;

    //Difumina
    Image imagen_letrero;
    Color color_imagen;

    bool desvanecer = false;
    bool Agarrado = false;

    void Start()
    {
        imagen_letrero = click_interativo.GetComponent<Image>();
        color_imagen = imagen_letrero.color;

        color_imagen.a = 0;
        imagen_letrero.color = color_imagen;
    }

    void OnEnable()//Cuando se activo el script 
    {
        if (objetoAgarrable != null)//pone cuando no esta vacia
        {
            objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
            objetoAgarrable.selectExited.AddListener(OcultarImagen);
        }
    }

    void OnDisable()//Cuando se desactiva el script 
    {
        if (objetoAgarrable != null)//quita cuando no esta vacia
        {
            objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);//selectEntered - evento( selecciona, toma o agarra un objeto interactuable.)
            objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
        }
    }
    void Update()
    {
        bool aparecer = desvanecer && !Agarrado;//si desvanecer y tabmien diferente agarrado

        if (aparecer)
            color_imagen.a += Time.deltaTime * 2f;
        else
            color_imagen.a -= Time.deltaTime * 2f;

        if (color_imagen.a > 1)
            color_imagen.a = 1;

        if (color_imagen.a < 0)
            color_imagen.a = 0;
        imagen_letrero.color = color_imagen;
    }

    // ---------Funciones --------- //
    void MostrarImagen(SelectEnterEventArgs argumento)//(clase Unity XR - variable local)
    {
        Agarrado = true;
    }

    void OcultarImagen(SelectExitEventArgs argumento)
    {
        Agarrado = false;
    }

    // ---------Trigger --------- //

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            desvanecer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            desvanecer = false;
        }
    }
}

