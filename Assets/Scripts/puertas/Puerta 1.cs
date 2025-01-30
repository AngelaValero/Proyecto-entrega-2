using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta1 : MonoBehaviour
{
    #region //referencias y elementos
    [Tooltip("Si es true la puerta no se puede usar")]
    public bool Locked = false;
    [Tooltip("True si se controla con palanca")]
    public bool Remote = false;
    [Space]
    [Tooltip("La puerta se puede abrir")]
    public bool CanOpen = true;
    [Tooltip("La puerta se puede cerrar")]
    public bool CanClose = true;
    [Space]
    [Tooltip("La puerta se abre con la redkey ( Ajustar que tipo de llave es)")]
    public bool RedLocked = false;
    public bool BlueLocked = false;
    [Tooltip("Conectar al jugador")]
    Jugador Jugador;
    [Space]
    public bool isOpened = false;
    [Range(0f, 4f)]
    [Tooltip("Velocidad de apertura, 3 grados por segundo(1-4)")]
    public float OpenSpeed = 3f;

    float distance;
    float angleView;
    Vector3 direction;

    [HideInInspector]
    public Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;

    void Start()
    {
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        Jugador = FindObjectOfType<Jugador>();
    }

    void Update()
    {
        if (!Remote && Input.GetKeyDown(KeyCode.E) && NearView())
            Action();

    }
    #endregion
    #region //Abrir/cerrar llave
    public void Action() // void para abrir y cerrar la puerta
    {
        if (!Locked)
        {
            // Verificacion key
            if (Jugador != null && RedLocked && Jugador.RedKey)
            {
                RedLocked = false;
                Jugador.RedKey = false;
            }
            else if (Jugador != null && BlueLocked && Jugador.BlueKey)
            {
                BlueLocked = false;
                Jugador.BlueKey = false;
            }

            // abrir cerrar
            if (isOpened && CanClose && !RedLocked && !BlueLocked)
            {
                isOpened = false;
            }
            else if (!isOpened && CanOpen && !RedLocked && !BlueLocked)
            {
                isOpened = true;
                rbDoor.AddRelativeTorque(new Vector3(0, 0, 20f));
            }

        }
    }
    #endregion

    bool NearView() // Si es cierto estas cerca de elementos interactivos
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 3f) return true; // angleView < 35f && 
        else return false;
    }

    private void FixedUpdate() // La puerta es un elemento fisico
    {
        if (isOpened)
        {
            currentLim = 2000f;
        }
        else
        {
            // currentLim = hinge.angle; // la puerta se cerrará sola
            if (currentLim > 1f)
                currentLim -= .5f * OpenSpeed;
        }

        // usa los valores
        hingeLim.max = currentLim;
        hingeLim.min = -currentLim;
        hinge.limits = hingeLim;
    }
}

