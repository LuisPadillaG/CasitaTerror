using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    PlayerInput playerInput;

    //Inspector cositas
    [Header("Configuracion del personaje")]
    [Range(1f, 50f)]
    public float corrida;
    [Header("Camara y Sensibilidad")]
    public Transform camaraTransform; 
    public float sensibilidadMouse = 0.1f;
    float rotacionX = 0f;
    Vector2 mousemovimientoloco;
    Vector2 inputMovimiento;


    Vector3 velocida;
    float tiempo;
    float movNormal;
    float duplicado;
    float contador_segundos_corrida;
    public bool activarModoVR = false;
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        playerInput = this.GetComponent<PlayerInput>();

        velocida = Vector3.zero;

        //tiempo = Time.deltaTime * corrida;
        corrida = 5f;
        movNormal = tiempo * corrida;
        duplicado = movNormal * 2;
        contador_segundos_corrida = 5f;
    }

    
    void Update()
    {
        //mouse movimiento loco
        mousemovimientoloco = playerInput.actions["look"].ReadValue<Vector2>();
        transform.Rotate(Vector3.up * mousemovimientoloco.x * sensibilidadMouse); 
        rotacionX -= mousemovimientoloco.y * sensibilidadMouse;
        rotacionX = Mathf.Clamp(rotacionX, -80f, 80f); 
        if (camaraTransform != null)
        {
            camaraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }
        else
        {
            Debug.Log("arrastra la camara aaaaaaaaaaaaaaaaaaaaaaaa");
        }

        // move ahora del jugador. 
        movNormal = corrida * Time.deltaTime;
        duplicado = movNormal * 2;
        inputMovimiento = playerInput.actions["move"].ReadValue<Vector2>();
        velocida.x = inputMovimiento.x;
        velocida.z = inputMovimiento.y;
        if (playerInput.actions["Sprint"].IsPressed())
        {
            movNormal = duplicado;
        }


        // ultima sección
        //transform.right es relativo al mundo.
        Vector3 direccion = transform.right * inputMovimiento.x + transform.forward * inputMovimiento.y;
        Debug.Log("direccion es" + direccion);
        characterController.Move(direccion * movNormal);
    }
}
