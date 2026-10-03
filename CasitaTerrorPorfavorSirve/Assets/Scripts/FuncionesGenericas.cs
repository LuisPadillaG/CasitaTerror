using UnityEngine;
using UnityEngine.InputSystem;

public class FuncionesGenericas : MonoBehaviour
{
    [Header("Jugador Opciones")]
    [SerializeField] bool a_camMovement = true;

    [Header("Referencias")]
    [SerializeField] PlayerInput playerInput;
    [SerializeField] Transform objetivoMovimiento; // Asigna 'Camera Offset' aquí

    [Header("Parámetros de Head Bob")]
    [SerializeField] float amplitud = 0.05f;
    [SerializeField] float velocidad = 8f;
    [SerializeField] float velocidadRetorno = 5f; // Suavidad para volver al origen

    private Vector3 posicionOriginal;
    private float timer = 0f;
    private bool posicionGuardada = false;

    void Start()
    {
        // Guardamos la posición en LateUpdate o en el primer frame de movimiento
        // para asegurar que el sistema de XR ya estableció la altura correcta.
    }

    void Update()
    {
        if (a_camMovement && objetivoMovimiento != null)
        {
            CamMovement();
        }
    }

    public void CamMovement()
    {
        // Guardar la posición inicial real si aún no se ha guardado
        if (!posicionGuardada)
        {
            posicionOriginal = objetivoMovimiento.localPosition;
            posicionGuardada = true;
        }

        // Lectura segura del Input Action
        InputAction moveAction = playerInput != null ? playerInput.actions.FindAction("Move") : null;

        Vector2 movimiento = Vector2.zero;
        if (moveAction != null)
        {
            movimiento = moveAction.ReadValue<Vector2>();
        }

        if (movimiento.sqrMagnitude > 0.01f)
        {
            // Continuar acumulando el ciclo de la onda seno
            timer += Time.deltaTime * velocidad;

            float movimientoY = Mathf.Sin(timer) * amplitud;

            Vector3 posicionObjetivo = posicionOriginal;
            posicionObjetivo.y += movimientoY;

            // Transición suave hacia la posición oscilada
            objetivoMovimiento.localPosition = Vector3.Lerp(
                objetivoMovimiento.localPosition,
                posicionObjetivo,
                Time.deltaTime * velocidadRetorno
            );
        }
        else
        {
            // Mantiene la continuidad de la onda sin reiniciar el timer a 0 de golpe
            timer = 0f;

            // Regresa de forma fluida y amortiguada a la posición inicial
            objetivoMovimiento.localPosition = Vector3.Lerp(
                objetivoMovimiento.localPosition,
                posicionOriginal,
                Time.deltaTime * velocidadRetorno
            );
        }
    }
}