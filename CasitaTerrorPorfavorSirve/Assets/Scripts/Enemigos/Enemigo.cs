using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        //navMeshAgent.SetDestination(Vector3.zero);
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(jugador.transform.position);
    }
}
