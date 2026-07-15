using UnityEngine;

public class Agua : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            RadiacionManager.instancia.MorirInstante();
        }
    }
}