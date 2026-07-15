using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadiacionManager : MonoBehaviour
{
    [SerializeField] private float radiacionMaxima = 100f;
    [SerializeField] private float velocidadSubida = 2f;
    [SerializeField] private Slider barraRadiacion;
    [SerializeField] private GameObject pantallaGameOver;

    private float radiacionActual = 0f;
    private bool muerto = false;

    public static RadiacionManager instancia;

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        if (muerto) return;

        radiacionActual += velocidadSubida * Time.deltaTime;
        radiacionActual = Mathf.Clamp(radiacionActual, 0f, radiacionMaxima);

        barraRadiacion.value = radiacionActual / radiacionMaxima;

        if (radiacionActual >= radiacionMaxima)
        {
            muerto = true;
            MostrarGameOver();
        }
    }

    public void BajarRadiacion(float cantidad)
    {
        radiacionActual -= cantidad;
    }

    void MostrarGameOver()
    {
        pantallaGameOver.SetActive(true);
        Time.timeScale = 0f; // pausa el juego
    }

    // El botón Reintentar llama esto
    public void Reintentar()
    {
        Time.timeScale = 1f; // restaura el tiempo antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MorirInstante()
    {
        muerto = true;
        MostrarGameOver();
    }
}