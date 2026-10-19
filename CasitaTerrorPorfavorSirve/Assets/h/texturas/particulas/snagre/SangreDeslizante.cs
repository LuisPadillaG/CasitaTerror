using UnityEngine;

public class SangreDeslizante : MonoBehaviour
{
    [SerializeField] private float velocidad = 0.15f;

    private Renderer renderizador;
    private Material materialInstancia;
    private Vector2 desplazamiento;

    void Start()
    {
        renderizador = GetComponent<Renderer>();
        materialInstancia = renderizador.material;
    }

    void Update()
    {
        desplazamiento.y += velocidad * Time.deltaTime;

        materialInstancia.SetTextureOffset(
            "_BaseMap",
            desplazamiento
        );
    }
}
