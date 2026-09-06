using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControladorEfectoRetro : MonoBehaviour
{
    [Header("Configuración URP")]
    public ScriptableRendererData rendererData;

    public string nombreDelEfecto = "Shader Graphs_RetroCustomEffect";

    [Header("Ajustes de la Escena")]
    public bool desactivarEnEstaEscena = true;

    private void Awake()
    {CambiarEstadoEfecto(!desactivarEnEstaEscena); }

    private void OnDestroy()
    { CambiarEstadoEfecto(true);// restaura el efecto 
    }

    private void CambiarEstadoEfecto(bool activar)
    {
        if (rendererData == null)
        {
            Debug.LogWarning("No se asignó");
            return;
        }

        foreach (var feature in rendererData.rendererFeatures)
        {
            if (feature != null)
            {
                if (feature.name == nombreDelEfecto || feature.name.Contains(nombreDelEfecto) || feature.name.Contains("Fullscreen"))
                { feature.SetActive(activar); }
            }
        }
    }
}
