using UnityEngine;

public class Normalizacion : MonoBehaviour
{
    [SerializeField] private Transform tank;
    [SerializeField] private Transform robot;
    [SerializeField] private float velocidadMovimiento = 1.5f;

    private Transform tankTransform;

    void Awake()
    {
        tankTransform = tank; // cachear referencia
    }

    void Update()
    {
        if (tankTransform == null || robot == null) return;

        // Dirección desde el tank hacia el robot
        Vector3 direccion = (robot.position - tankTransform.position).normalized;

        // Movimiento
        tankTransform.position += direccion * velocidadMovimiento * Time.deltaTime;
    }
}
