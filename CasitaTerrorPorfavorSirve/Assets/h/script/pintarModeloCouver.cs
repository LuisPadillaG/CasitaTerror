using UnityEngine;

public class pintarModeloCouver : MonoBehaviour
{
    [SerializeField] GameObject modeloOriginal;
    [SerializeField] GameObject modelHover;

    bool Agarrado;

    void Start()
    {
        
      
        modeloOriginal.SetActive(true);
        modelHover.SetActive(true);
        //AgarrarModelo.SetActive(true);
        //SoltarModelo.SetActive(true);
        Agarrado = true;
        
    }

    public void HoverModelo()
    {
        if (Agarrado) return; //NO EJECUTES LO DE ABAJO
        modeloOriginal.SetActive(false);
        modelHover.SetActive(false);
    }

    public void UnHoverModelo()
    {
        modeloOriginal.SetActive(true);
        modelHover.SetActive(true);
    }

    public void AgarrarModelo()
    {
        Agarrado = true;
    }
     public void SoltarModelo()
    {
        Agarrado = false;
    }

}
