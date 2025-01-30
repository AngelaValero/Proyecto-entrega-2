using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Stats _stats;  // Referencia al script de estadísticas
    public float velocidadGiro = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Verifica si el objeto con el que colisiona es el jugador
        {
            _stats.monedas++;  // Aumenta el contador de monedas
            Destroy(gameObject);  // Destruye la moneda
        }
    }


    private void Update()
    {
        transform.Rotate(0, velocidadGiro * Time.deltaTime, 0);
    }
}

