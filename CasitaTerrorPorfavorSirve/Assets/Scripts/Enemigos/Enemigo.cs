using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject jugador;
    Animator animationVillano;
    Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //navMeshAgent.SetDestination(Vector3.zero);
        jugador = GameObject.FindGameObjectWithTag("MainCamera");
        animationVillano = this.GetComponentInChildren<Animator>();
        navMeshAgent.speed = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(jugador.transform.position);
        if (animationVillano)
        {
            //Debug.Log(true);
        }
        //animationVillano.SetInteger("Estados", 2);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animationVillano.SetInteger("Estados", 1);
            Debug.Log("HEllooooooooooooooooooooooooooooooooooooooo");
            navMeshAgent.speed = 2f;
        }
        else
        {
            //animationVillano.SetInteger("Estados", 2);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animationVillano.SetInteger("Estados", 2);
            navMeshAgent.speed = 1.2f;
            Debug.Log("ByeBye");
        }
    }
}
