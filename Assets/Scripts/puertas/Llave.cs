using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorKey : MonoBehaviour
{
    [Tooltip("True - red key object, false - blue key")]
    public bool isRedKey = true;
    Jugador jugador;

    // NearView()
    float distancia;
    float vistaAngulo;
    Vector3 direccion;

    private void Start()
    {
        jugador = FindObjectOfType<Jugador>(); // Te guardas la llave
    }

    void Update()
    {
        if ( NearView() && Input.GetKeyDown(KeyCode.E) )
        {
            if (isRedKey) jugador.RedKey = true;
            else jugador.BlueKey = true;
            Destroy(gameObject);
        }
    }

    bool NearView() // Si estas cerca de un objeto
    {
        distancia = Vector3.Distance(transform.position, Camera.main.transform.position);
        direccion = transform.position - Camera.main.transform.position;
        vistaAngulo = Vector3.Angle(Camera.main.transform.forward, direccion);
        if (distancia < 2f) return true; // angleView < 35f && 
        else return false;
    }
}
