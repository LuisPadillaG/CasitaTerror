using UnityEngine;
using UnityEngine.InputSystem;

public class AnimacionManoDerecha : MonoBehaviour
{

    PlayerInput playerInput;
    [SerializeField] RiggeadorManos manoDerecha;


    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
    }

    
    void Update()
    {
        //Debug.Log(playerInput.actions["Select Value"].ReadValue<float>());
        manoDerecha.gripSlider = playerInput.actions["XRI Right Interaction/Select Value"].ReadValue<float>();
        manoDerecha.triggerSlider = playerInput.actions["XRI Right Interaction/Activate Value"].ReadValue<float>();//si se esta ejecutando ,dedo indicador
        manoDerecha.botonAPresionado = playerInput.actions["XRI Right Interaction/BotonesFrontales"].IsPressed();//si esta presionando
    }
}
