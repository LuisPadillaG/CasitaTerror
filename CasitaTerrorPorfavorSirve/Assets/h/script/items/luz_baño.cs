using UnityEngine;

public class luz_baño : MonoBehaviour
{
    Light[] focos;

    float intensidad;
    public float velocidad = 0.2f;
    bool aumentando;

    void Start()
    {
        focos = GetComponentsInChildren<Light>();
        Valores();
    }

    void Update()
    {
        switch_baño();
    }

    void Valores()
    {
        intensidad = 0f;
        aumentando = true;
    }

    void switch_baño()
    {
        if (aumentando)
        {
            intensidad += velocidad * Time.deltaTime;

            if (intensidad >= 1f)
            {
                intensidad = 1f;
                aumentando = false;
            }
        }
        else
        {
            intensidad -= velocidad * Time.deltaTime;

            if (intensidad <= 0f)
            {
                intensidad = 0f;
                aumentando = true;
            }
        }

        focos[0].intensity = 0.03f + intensidad * 0.03f;// Primera - 0.3 y 0.6
        focos[1].intensity = 42f + intensidad * 3f; // Segunda - 42 y 45

        //focos[0].intensity = 0.3f + intensidad * (0.6f - 0.3f);
        //focos[1].intensity = 42f + intensidad * (45f - 42f);
    }
}
