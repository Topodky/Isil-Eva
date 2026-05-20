using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Meta : MonoBehaviour
{
    [SerializeField] private GameObject pantallaVictoria;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            pantallaVictoria.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}