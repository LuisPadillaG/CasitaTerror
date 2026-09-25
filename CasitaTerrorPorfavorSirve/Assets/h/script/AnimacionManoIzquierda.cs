using UnityEngine;
using UnityEngine.InputSystem;

public class AnimacionManoIzquierda : MonoBehaviour
{

    PlayerInput playerInput;
    [SerializeField] RiggeadorManos manoIzquierda;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = this.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerInput.actions["Select Value"].ReadValue<float>());
        manoIzquierda.gripSlider = playerInput.actions["XRI Right Interaction/Select Value"].ReadValue<float>();//la mitad de la mano
        manoIzquierda.triggerSlider = playerInput.actions["XRI Right Interaction/Activate Value"].ReadValue<float>();//si se esta ejecutando ,dedo indicador
        manoIzquierda.botonAPresionado = playerInput.actions["XRI Right Interaction/BotonesFrontales"].IsPressed();//si esta presionando

    }
}
