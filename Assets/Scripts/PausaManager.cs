using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PausaManager : MonoBehaviour
{
    [SerializeField] private GameObject pantallaPausa;

    private bool pausado = false;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pausado)
                Continuar();
            else
                Pausar();
        }
    }

    void Pausar()
    {
        pantallaPausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Continuar()
    {
        pantallaPausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // carga la escena 0, que será el menú principal
    }
}