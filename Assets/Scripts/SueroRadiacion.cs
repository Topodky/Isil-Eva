using UnityEngine;

public class SueroRadiacion : MonoBehaviour
{
    [SerializeField] private float cantidadCura = 25f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            RadiacionManager.instancia.BajarRadiacion(cantidadCura);
            Destroy(gameObject);
        }
    }
}