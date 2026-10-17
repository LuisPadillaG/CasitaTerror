using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Canvas_Agarrar : MonoBehaviour
{
    /*
    public GameObject imagenCanvas;
    public XRGrabInteractable objetoAgarrable;

    
    void Start()
    {
        imagenCanvas.SetActive(false);



        objetoAgarrable.selectEntered.AddListener(MostrarImagen);
        objetoAgarrable.selectExited.AddListener(OcultarImagen);    
    }

    void MostrarImagen(SelectEnterEventArgs argumento)
    {
        imagenCanvas.SetActive(true);
    }

    void OcultarImagen(SelectExitEventArgs argumento)
    {
        imagenCanvas.SetActive(false);
    }

    void OnDestroy()
    {
        objetoAgarrable.selectEntered.RemoveListener(MostrarImagen);
        objetoAgarrable.selectExited.RemoveListener(OcultarImagen);
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rompible")
        {
            Debug.Log("me electrocutaste pedrito");
            Rigidbody rogo = other.GetComponent<Rigidbody>();
            rogo.constraints = RigidbodyConstraints.None;
            Destroy(other.gameObject, 1);
            Debug.Log("Lo logramos");
            //destroy objeto
        }
    }
}
