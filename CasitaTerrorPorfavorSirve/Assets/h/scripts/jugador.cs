using UnityEngine;
using UnityEngine.InputSystem;

public class jugador : MonoBehaviour
{
    // COMPONENTES
    CharacterController characterController;
    Transform componenteTransform;

    // MOVIMIENTO
    Vector3 posicion;
    Vector3 rotacion;
    Vector3 gravedad;
    Vector3 escala;

    float velocidad_lineal;
    float velocidad_lineal_diagonal;

    // PREFAB
    //public GameObject prefabCubo;


    void Start()
    {
        // Obtener componentes
        componenteTransform = this.GetComponent<Transform>();
        characterController = this.GetComponent<CharacterController>();

        // Posición inicial
        posicion = new Vector3(0, 0.5f, 0);

        // Rotación inicial
        rotacion = Vector3.zero;

        // Gravedad
        gravedad = Vector3.zero;

        // Escala inicial
        escala = Vector3.one;

        // Velocidades
        velocidad_lineal = 3f;
        velocidad_lineal_diagonal = 0.5f;
    }


    void Update()
    {

        // MOVIMIENTO
        if (Keyboard.current.rightArrowKey.isPressed)//->// DERECHA
            posicion.x += velocidad_lineal * Time.deltaTime;
        if (Keyboard.current.leftArrowKey.isPressed)//<-  // IZQUIERDA
            posicion.x -= velocidad_lineal * Time.deltaTime;
        if (Keyboard.current.upArrowKey.isPressed)//// ADELANTE
            posicion.z += velocidad_lineal * Time.deltaTime;
        if (Keyboard.current.downArrowKey.isPressed)//v   // ATRÁS
            posicion.z -= velocidad_lineal * Time.deltaTime;

        // ROTACIÓN MONO
        if (Keyboard.current.rightArrowKey.isPressed)   // DERECHA
        {   rotacion.y = -90;}
        if (Keyboard.current.leftArrowKey.isPressed) // IZQUIERDA
        { rotacion.y = 90;}
        if (Keyboard.current.upArrowKey.isPressed)  // ADELANTE
        { rotacion.y = 180;}
        if (Keyboard.current.downArrowKey.isPressed)  // ATRÁS
        { rotacion.y = 0; }


        // DIAGONALES
        if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)// DERECHA + ADELANTE
        {
            rotacion.y = -135;
            posicion.x += 0.5f * Time.deltaTime;//Para que no se incremente las dos posiciones
            posicion.z += 0.5f * Time.deltaTime;
            /* oh tambien puede ser esto
            posicion.x += velocidad_lineal_diagonal * Time.deltaTime;
            posicion.z += velocidad_lineal_diagonal * Time.deltaTime;
            */
        }
        if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)// DERECHA + ATRÁS
        {
            rotacion.y = -45;
            posicion.x += 0.5f * Time.deltaTime;
            posicion.z += 0.5f * Time.deltaTime;
        }
        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.upArrowKey.isPressed)// IZQUIERDA + ADELANTE
        {
            rotacion.y = 135;
            posicion.x += 0.5f * Time.deltaTime;
            posicion.z += 0.5f * Time.deltaTime;
        }
        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.downArrowKey.isPressed)// IZQUIERDA + ATRÁS
        {
            rotacion.y = 45;
            posicion.x += 0.5f * Time.deltaTime;
            posicion.z += 0.5f * Time.deltaTime;
        }


        // GRAVEDAD
        if (characterController.isGrounded)
        { gravedad.y = -1f; }
        else
        {  gravedad.y += -9.81f * Time.deltaTime; }


        // SALTO
        if (Keyboard.current.spaceKey.wasPressedThisFrame && characterController.isGrounded)
        {gravedad.y = 5f; }


        // Aplicar gravedad al movimiento
        gravedad.y += -9.81f * Time.deltaTime;
        characterController.Move(gravedad * Time.deltaTime);

        // LIMITES
        if (posicion.x > 4.5f)
        { posicion.x = 4.5f; }
        if (posicion.x < -4.5f)
        { posicion.x = -4.5f; }
        if (posicion.z > 4.5f)
        { posicion.z = 4.5f; }
        if (posicion.z < -4.5f)
        { posicion.z = -4.5f; }

        // ESCALA
        if (Keyboard.current.kKey.wasPressedThisFrame) //MAYOR
        {  escala.z *= 2; }
        if (Keyboard.current.lKey.wasPressedThisFrame) //MENOR
        {  escala.z /= 2; }

        /*
        // CREAR CUBO
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(
                prefabCubo,
                Vector3.zero,
                Quaternion.Euler(0, 0, 0)
            );
        }
        */

        // APLICAR TRANSFORM
        componenteTransform.position = posicion;
        componenteTransform.rotation =  Quaternion.Euler(rotacion);
        componenteTransform.localScale = escala;
    }
}