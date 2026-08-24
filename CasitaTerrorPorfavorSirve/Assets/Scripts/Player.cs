using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    float tiempo;
    
    //Inspector
    [Header("Configuracion del personaje")]
    [Range(1f, 50f)]
    public float corrida = 1f;
    [SerializeField] Vector3 velocida;
    PlayerInput playerInput;
    float movNormal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        playerInput = this.GetComponent<PlayerInput>();
        velocida = Vector3.zero;
        tiempo = Time.deltaTime * corrida;
        movNormal = tiempo * corrida;
    }

    // Update is called once per frame
    void Update()
    {
        movNormal = corrida * tiempo; //lo pongo así para que cada frame recuerde su valor original. Si existe un boton de correr, lo multiplico X2
        Vector2 inputMovimiento = playerInput.actions["move"].ReadValue<Vector2>();

        velocida.x = inputMovimiento.x;
        velocida.z = inputMovimiento.y; 
        //Debug.Log(playerInput.actions["move"].ReadValue<Vector3>());
        characterController.Move(velocida * movNormal);


    }
}
