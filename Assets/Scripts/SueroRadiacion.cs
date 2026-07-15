using UnityEngine;

public class SueroRadiacion : MonoBehaviour
{
    [SerializeField] private float cantidadCura = 25f;
    [SerializeField] private AudioClip sonidoCercano;
    [SerializeField] private AudioClip sonidoRecogido;
    [SerializeField] private float radioCercania = 3f;

    private AudioSource audioSource;
    private bool sonandoCercano = false;
    private bool recogido = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (recogido) return;

        // Detecta si el jugador está cerca
        Collider2D jugador = Physics2D.OverlapCircle(transform.position, radioCercania, LayerMask.GetMask("Player"));

        if (jugador != null && !sonandoCercano)
        {
            sonandoCercano = true;
            audioSource.clip = sonidoCercano;
            audioSource.loop = true;
            audioSource.Play();
        }
        else if (jugador == null && sonandoCercano)
        {
            sonandoCercano = false;
            audioSource.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !recogido)
        {
            recogido = true;
            audioSource.loop = false;
            audioSource.Stop();
            audioSource.PlayOneShot(sonidoRecogido);
            RadiacionManager.instancia.BajarRadiacion(cantidadCura);
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, sonidoRecogido.length);
        }
    }
}