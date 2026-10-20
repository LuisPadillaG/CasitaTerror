using UnityEngine;

public class Canvas_Palanca : MonoBehaviour
{
    // Sonido
    public AudioSource audioAmbiental;
    bool Destrosar = false;

    void Start()
    {
        // Componentes();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rompible")
        {


            /*
             private void OnTriggerEnter(Collider other)
            {
                if (other.tag == "rompible")
                {
                    Debug.Log("me electrocutaste pedrito");
                    Rigidbody rogo = other.GetComponent<Rigidbody>();
                    rogo.constraints = RigidbodyConstraints.None;
                    Destroy(other.gameObject, 1);
                    Debug.Log("Lo logramos");
                    //destroy objeto
                    Prendido();
                }
            }

             */

            Debug.Log("me electrocutaste pedrito");
            Rigidbody rogo = other.GetComponent<Rigidbody>();

            if (rogo != null)
            rogo.constraints = RigidbodyConstraints.None;
            

            Destroy(other.gameObject, 1);
            Debug.Log("Lo logramos");

            
            Prendido();// Sonid
        }
    }

    void Prendido()
    {
        audioAmbiental.volume = 0.6f;
        audioAmbiental.PlayOneShot(audioAmbiental.clip);
    }




}
