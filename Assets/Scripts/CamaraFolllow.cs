using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform objetivo; // el jugador
    [SerializeField] private float suavizado = 5f;
    [SerializeField] private Vector2 limiteMin; // límite izquierdo/abajo del nivel
    [SerializeField] private Vector2 limiteMax; // límite derecho/arriba del nivel

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - objetivo.position;
    }

    void LateUpdate()
    {
        Vector3 posObjetivo = objetivo.position + offset;

        // Limita la cámara al nivel
        float x = Mathf.Clamp(posObjetivo.x, limiteMin.x, limiteMax.x);
        float y = Mathf.Clamp(posObjetivo.y, limiteMin.y, limiteMax.y);

        // Mueve suavemente
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), suavizado * Time.deltaTime);
    }
}