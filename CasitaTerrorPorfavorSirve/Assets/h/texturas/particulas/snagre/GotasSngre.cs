using UnityEngine;

public class GotasSngre : MonoBehaviour
{
    [SerializeField] private float tiempoEspera = 2f;
    [SerializeField] private float velocidadCaida = 1.5f;

    private ParticleSystem particulas;
    private ParticleSystem.Particle[] gotas;
    private float[] tiemposEspera;

    void Awake()
    {
        particulas = GetComponent<ParticleSystem>();

        int maximo = particulas.main.maxParticles;

        gotas = new ParticleSystem.Particle[maximo];
        tiemposEspera = new float[maximo];
    }

    void Update()
    {
        int cantidad = particulas.GetParticles(gotas);

        for (int i = 0; i < cantidad; i++)
        {
            ParticleSystem.Particle gota = gotas[i];

            // Espera antes de empezar a caer.
            if (gota.remainingLifetime >
                gota.startLifetime - tiempoEspera)
            {
                gota.velocity = Vector3.zero;
            }
            else
            {
                // Después empieza a caer.
                gota.velocity = new Vector3(
                    0f,
                    -velocidadCaida,
                    0f
                );
            }

            gotas[i] = gota;
        }

        particulas.SetParticles(gotas, cantidad);
    }
}
