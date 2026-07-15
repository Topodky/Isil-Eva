using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Meta : MonoBehaviour
{
    [SerializeField] private GameObject pantallaVictoria;
    [SerializeField] private bool esUltimoNivel = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            pantallaVictoria.SetActive(true);
            StartCoroutine(SiguienteEscena());
        }
    }

    IEnumerator SiguienteEscena()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        if (esUltimoNivel)
            SceneManager.LoadScene("Menu");
        else
            SceneManager.LoadScene("Nivel1");
    }
}