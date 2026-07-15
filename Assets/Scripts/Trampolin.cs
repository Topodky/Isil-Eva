using UnityEngine;
using System.Collections;

public class Trampolin : MonoBehaviour
{
    [Header("Lanzamiento")]
    [SerializeField] private float fuerzaLanzamiento = 15f;

    [Header("Referencias")]
    [SerializeField] private Animator animator;

    [Header("Audio")]
    [SerializeField] private AudioClip sonidoCompresion;
    [SerializeField] private AudioClip sonidoLanzamiento;

    [Header("Collider")]
    [SerializeField] private float offsetComprimido = -4.32f;

    private AudioSource audioSource;
    private BoxCollider2D boxCollider;
    private bool activado = false;
    private Vector2 offsetOriginal;
    private Rigidbody2D ultimoObjeto = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        offsetOriginal = boxCollider.offset;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (activado) return;

        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        if (rb == ultimoObjeto) return;

        bool golpeDesdeArriba = false;
        foreach (ContactPoint2D contacto in col.contacts)
        {
            if (contacto.normal.y < -0.5f)
            {
                golpeDesdeArriba = true;
                break;
            }
        }

        if (!golpeDesdeArriba) return;
        if (rb.linearVelocity.y > 0f) return;

        ultimoObjeto = rb;
        StartCoroutine(ActivarTrampolin(rb));
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        // Ya no ponemos null aquí
    }

    IEnumerator ActivarTrampolin(Rigidbody2D rb)
    {
        activado = true;

        animator.SetTrigger("Launch");

        if (audioSource && sonidoCompresion)
            audioSource.PlayOneShot(sonidoCompresion);

        boxCollider.offset = new Vector2(
            offsetOriginal.x,
            offsetOriginal.y + offsetComprimido
        );

        yield return new WaitForSeconds(1f);

        if (audioSource && sonidoLanzamiento)
            audioSource.PlayOneShot(sonidoLanzamiento);

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            fuerzaLanzamiento
        );

        boxCollider.offset = offsetOriginal;

        yield return new WaitForSeconds(1f);
        activado = false;
        ultimoObjeto = null;
    }
}