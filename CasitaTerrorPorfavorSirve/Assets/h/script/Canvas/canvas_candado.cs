using UnityEngine;

public class canvas_candado : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "candado")
        {
            Debug.Log("me electrocutaste pedrito");
            Rigidbody rogo = other.GetComponent<Rigidbody>();
            rogo.constraints = RigidbodyConstraints.None;
            Destroy(other.gameObject, 1);
            Debug.Log("Lo logramos");
            //destroy objeto
        }
    }
}
