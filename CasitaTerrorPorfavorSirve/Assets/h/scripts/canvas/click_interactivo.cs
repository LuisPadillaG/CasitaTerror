using UnityEngine;
using UnityEngine.InputSystem;

public class click_interactivo : MonoBehaviour
{

    [SerializeField] GameObject click_interativo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            click_interativo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            click_interativo.SetActive(false);
        }
    }


}
