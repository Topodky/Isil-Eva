using UnityEngine;
using TMPro;

public class TutorialZonas : MonoBehaviour
{
    [SerializeField] private string mensaje;
    [SerializeField] private GameObject panelMensaje;
    [SerializeField] private TextMeshProUGUI textoMensaje;
    [SerializeField] private float duracion = 3f;

    private bool activado = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !activado)
        {
            activado = true;
            textoMensaje.text = mensaje;
            panelMensaje.SetActive(true);
            Invoke(nameof(OcultarMensaje), duracion);
        }
    }

    void OcultarMensaje()
    {
        panelMensaje.SetActive(false);
    }
}