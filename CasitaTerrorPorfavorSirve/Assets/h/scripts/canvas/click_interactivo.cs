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

    
    bool aparecer;//float velocidad_difuminado;
    bool jugadorCerca;
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
        Difuminar_Imagen();
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
        jugadorCerca = false;
        //desaparesca - color
        color_imagen.a = 0;
        imagen_letrero.color = color_imagen; //imagen_letrero.alpha = 0;
    }

    //---------Funciones
    void Difuminar_Imagen()//aparecer
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

    /*
    public void ExplotarImagen()
    {
        click_interativo.SetActive(true);
    }
    public void RespawnearImagen()
    {
        click_interativo.SetActive(false);
    }

    */

    // --------- Agarrar y soltar ---------



    public void MostrarImagen(SelectEnterEventArgs argumento)
    {
        //imagen.SetActive(true);
        aparecer = false;
    }
    public void OcultarImagen(SelectExitEventArgs argumento)
    {
        //imagen.SetActive(false);
        //aparecer = false;
        aparecer = jugadorCerca;
    }
    /*
    void OnDestroy()
    {
        objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
        objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
    }
    */
    private void OnTriggerEnter(Collider other)//aparecer
    {
        //objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        //objetoAgarrable.selectExited.AddListener(OcultarImagen);
        if (other.CompareTag("Player"))
        {
            //click_interativo.SetActive(true); 
            jugadorCerca = true;
            aparecer = !objetoAgarrable.isSelected;
        }
    }

    private void OnTriggerExit(Collider other)//aparecer
    {
        if (other.CompareTag("Player"))
        {
            //aparecer = false;//click_interativo.SetActive(false);
            jugadorCerca = false;
            aparecer = false;
        }

        //objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
        //objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
    }

    /*
    void OnDestroy()
    {
        if (objetoAgarrable != null)
        {
            objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
            objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
        }
    }
    */
}
