using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [SerializeField] private float fuerzaLanzamiento = 15f;

    void OnCollisionEnter2D(Collision2D col)
    {
        // Solo actúa si el jugador cae desde arriba
        if (col.gameObject.CompareTag("Player"))
        {
            // Verificamos que venga cayendo (velocidad Y negativa)
            Rigidbody2D rbJugador = col.gameObject.GetComponent<Rigidbody2D>();
            if (rbJugador.linearVelocity.y <= 0.1f)
            {
                PlayerController jugador = col.gameObject.GetComponent<PlayerController>();
                jugador.Lanzar(Vector2.up * fuerzaLanzamiento);
            }
        }
    }
}