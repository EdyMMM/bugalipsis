using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMovement : MonoBehaviour
{
    // Header es para mostar y facilitar la separación de cosas en el editor
    [Header("Movement")]
    public float speed = 5f;
    public float turnForce = 12f;

    [Header("Obstacle Avoidance")]
    public float rayDistance = 2f;     // Esto es para darle "vision" a la IA y que pueda ver a cierta disctancia
    public LayerMask obstacleMask;     // Esto es una layerMask, en otras palabars, un tipo específico a lo que queremos llamar en un futuro
    public float avoidStrength = 20f;  // Esto es para aumentar la fuerza de giro al detectar un obstaculo

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * speed);

        // Estos son para asignar las direcciones
        Vector2 forward = transform.up;
        Vector2 left = Quaternion.Euler(0, 0, 30) * forward;
        Vector2 right = Quaternion.Euler(0, 0, -30) * forward;

        // Aqui, usamos algo llamado Raycast, que es basicamente un laser para detectar cosas, para ver si la IA detecta algo enfrente, a la izquierda o a la derecha
        // Aqui usamos lo del LayerMask, esto para decirle al Raycast "solo detecta las cosas que estén en este layer, ignora todo lo demas"
        RaycastHit2D hitForward = Physics2D.Raycast(transform.position, forward, rayDistance, obstacleMask);  // Los 3 funcionan de la misma manera, al asignarlo le decimos, empieza en ti mismo, en esta direccion, por tanta distancia y checa este layer
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, left, rayDistance, obstacleMask);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, right, rayDistance, obstacleMask);

        float torque = 0f;

        // Checamos si hay un obstaculko enfrente y girar mas fuerte
        if (hitForward.collider != null)
        {
            torque = avoidStrength;
        }

        // Checamos si hay un obstaculo a la izquierda y giramos a la derecha
        if (hitLeft.collider != null)
        {
            torque -= avoidStrength;
        }

        // Checamos si hay un obstaculo a la izquierda y giramos a la izquierda
        if (hitRight.collider != null)
        {
            torque += avoidStrength;
        }

        rb.AddTorque(torque * turnForce * Time.fixedDeltaTime);  // Aumentamos la fuerza que checamos antes y la añadimos
    }

    private void OnDrawGizmosSelected()
    {
        // Esto es para mostrar en el editor la vista de la IA
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * rayDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, 30) * transform.up * rayDistance);
        Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -30) * transform.up * rayDistance);
    }
}
