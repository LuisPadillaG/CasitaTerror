using UnityEngine;

public class Canvas_Palanca : MonoBehaviour
{
    //focos
    public AudioSource audioAmbiental;
    bool Destrosar = false;

    void Start()
    {
        //Componentes();
        
    }

    void Update()
    {
      
    }

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

    void Prendido()
    {
        if (!Destrosar)
        {
            audioAmbiental.volume = 0.6f;
            audioAmbiental.Play();
            if(Destrosar == false)
            {
                audioAmbiental.volume = 0f;
                audioAmbiental.Stop();
            }
        }
       
    }


}
