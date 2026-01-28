using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDrive2D : MonoBehaviour
{
    [SerializeField]HORMIGA antData;
    public SpriteRenderer spriteRenderer;
    public float speed = 5f;
    public float turnForce = 10f;
    private Rigidbody2D rb;

    private Vector2 input;

    private PlayerActions actions;

    private Animator animator;

    private void Awake()
    {
       spriteRenderer.sprite = antData.antSkin;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (!TryGetComponent(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        actions = new PlayerActions();
        actions.Enable();
        actions.Game.Enable();
    }

    void Update()
    {
        input = actions.Game.Move.ReadValue<Vector2>();
        if (input.magnitude > 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void FixedUpdate()
    {
        float acceleration = input.y * speed;
        float turn = -input.x * turnForce ;

        if (acceleration != 0)
        {
            rb.AddForce(transform.up * acceleration);
        }
        if(turn != 0)
        {
            Debug.Log("Applying torque: " + turn);
            rb.AddTorque(turn);
        }
    }
}
