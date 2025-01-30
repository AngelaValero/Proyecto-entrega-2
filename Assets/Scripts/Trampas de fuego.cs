using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trampasdefuego : MonoBehaviour
{
    public GameObject trampa; // La trampa (como el Fire String)
    public GameObject player; // El jugador
    public ProgressBar pG; // Barra de progreso (asumo que es la vida del jugador)
    public int dano = 10; // Daño que causará la trampa
    private static bool activa = true; // Estado de la trampa

    private void Start()
    {
        trampa.SetActive(false); // Asegurar que la trampa esté desactivada al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador entra
        {
            if (activa)
            {
                trampa.SetActive(true); // Activa la trampa

                activa = false; // Evita que se active repetidamente
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trampa.SetActive(false); // Opcional: Desactiva la trampa cuando el jugador sale
            activa = true; // Resetea la trampa para que pueda activarse nuevamente
        }
    }
}

