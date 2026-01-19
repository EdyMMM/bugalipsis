using UnityEngine;

public class FUERZADEAGUA : MonoBehaviour
{
    [SerializeField] float Fuerza = 10f;

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddForce(transform.up * Fuerza*Time.deltaTime);
    }
 

}
