using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class click_interactivo : MonoBehaviour
{
    //aparece no aparce
    [SerializeField] GameObject click_interativo;

    //Apararce
    GameObject imagen;
    public XRGrabInteractable objetoAgarrable;

    //Difumina
    Image imagen_letrero;//CanvasGroup imagen_letrero;
    Color color_imagen;

    //float velocidad_difuminado;
    bool aparecer;
    void Start()
    {
        Componentes();
        Valores();
        objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        objetoAgarrable.selectExited.AddListener(OcultarImagen);
    }

    void Update()
    {
        //Rotacion_Cartelon();
        Difuminar_Cartelon();
        //objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        //objetoAgarrable.selectExited.AddListener(OcultarImagen);
    }

    void Componentes()
    {
        //cartel difuminar  //desaparesca - color
        imagen_letrero = click_interativo.GetComponent<Image>();//imagen_letrero = click_interativo.GetComponent<CanvasGroup>();// Busca imagen
        color_imagen = imagen_letrero.color;

        /*//cartel aparecer
        imagen.SetActive(false);
        objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        objetoAgarrable.selectExited.AddListener(OcultarImagen);
        */
       
    }


    void Valores()
    {
        aparecer = false;

        //desaparesca - color
        color_imagen.a = 0;
        imagen_letrero.color = color_imagen; //imagen_letrero.alpha = 0;
    }

    //---------Funciones
    void Difuminar_Cartelon()//aparecer
    {
        if (aparecer)
            color_imagen.a += Time.deltaTime * 2;//imagen_letrero.alpha += Time.deltaTime * 2;
        else
            color_imagen.a -= Time.deltaTime * 2;//imagen_letrero.alpha -= Time.deltaTime * 2;


        if (color_imagen.a > 1)
            color_imagen.a = 1;

        if (color_imagen.a < 0)
            color_imagen.a = 0;

        imagen_letrero.color = color_imagen;
        /*
        //liminaciones
        if (imagen_letrero.alpha > 1)
            imagen_letrero.alpha = 1;

        if (imagen_letrero.alpha < 0)
            imagen_letrero.alpha = 0;
        */
    }
    //void MostrarImagen()
    //{
    //    if (Keyboard.current.)
    //    {
    //        aparecer = true;
    //    }
    //    else
    //    {
    //        aparecer = false;
    //    }
    //}
    public void ExplotarImagen()
    {
        click_interativo.SetActive(true);
    }
    public void RespawnearImagen()
    {
        click_interativo.SetActive(false);
    }
    public void MostrarImagen(SelectEnterEventArgs argumento)
    {
        //imagen.SetActive(true);
        aparecer = true;
    }
    public void OcultarImagen(SelectExitEventArgs argumento)
    {
        //imagen.SetActive(false);
        aparecer = false;
    }
    void OnDestroy()
    {
        objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
        objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
    }
    

    private void OnTriggerEnter(Collider other)//aparecer
    {
        objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        objetoAgarrable.selectExited.AddListener(OcultarImagen);
        if (other.CompareTag("Player"))
        {
            aparecer = true;//click_interativo.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)//aparecer
    {
        if (other.CompareTag("Player"))
        {
            aparecer = false;//click_interativo.SetActive(false);
        }

        objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
        objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
    }


}
