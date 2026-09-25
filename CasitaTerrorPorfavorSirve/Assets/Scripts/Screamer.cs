using Unity.VisualScripting;
using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    float valor;
    Vector3 posicion;
    [Range(0f, 2f)]
    [SerializeField] float velocidadAnimacion = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valor = 0;
        posicion = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(valor > 1)
        {
            valor = 0;
        }
        valor += 1.4f * Time.deltaTime;
        posicion.z = curve.Evaluate(valor) * 3;
        //this.transform.localPosition = posicion;
    }
}
