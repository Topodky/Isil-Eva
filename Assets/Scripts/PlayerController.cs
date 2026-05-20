using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private Transform puntoSuelo; // objeto hijo vacío en los pies del jugador

    private Rigidbody2D rb;
    private float movimiento;
    private Vector3 escalaInicial;
    private bool enSuelo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        // Detectar suelo
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, 0.1f, capaSuelo);

        // Input (igual que antes)
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            movimiento = -1;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            movimiento = 1;
        else
            movimiento = 0;

        // Animaciones (igual que antes)
        animator.SetBool("Idle", movimiento == 0);
        animator.SetBool("Run", movimiento != 0);

        // Voltear (igual que antes)
        if (movimiento != 0)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(movimiento) * Mathf.Abs(escalaInicial.x),
                escalaInicial.y,
                escalaInicial.z
            );
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);
    }

    // El trampolín llama esto — tú nunca lo llamas manualmente
    public void Lanzar(Vector2 fuerza)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // resetea Y antes de lanzar
        rb.AddForce(fuerza, ForceMode2D.Impulse);
    }
}