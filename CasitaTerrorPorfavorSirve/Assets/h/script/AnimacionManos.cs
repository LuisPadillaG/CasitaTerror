using UnityEngine;
using UnityEngine.InputSystem;

public class AnimacionManos : MonoBehaviour
{

    [SerializeField] RiggeadorManos manoDerecha;
    [SerializeField] RiggeadorManos manoIzquierda;

    PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log(playerInput.actions["Select Value"].ReadValue<float>());
        manoIzquierda.gripSlider = playerInput.actions["Select Value Izquierda"].ReadValue<float>();
        manoIzquierda.triggerSlider = playerInput.actions["Activate Value Izquierda"].ReadValue<float>();//si se esta ejecutando ,dedo indicador
        manoIzquierda.botonAPresionado = playerInput.actions["BotonesFrontales Izquierda"].IsPressed();//si esta presionando


        //Debug.Log(playerInput.actions["Select Value"].ReadValue<float>());
        manoDerecha.gripSlider = playerInput.actions["Select Value Derecha"].ReadValue<float>();
        manoDerecha.triggerSlider = playerInput.actions["Activate Value Derecha"].ReadValue<float>();//si se esta ejecutando ,dedo indicador
        manoDerecha.botonAPresionado = playerInput.actions["BotonesFrontales Derecha"].IsPressed();//si esta presionando


    }
}
//