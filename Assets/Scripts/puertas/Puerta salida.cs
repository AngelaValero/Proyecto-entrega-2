using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorScript : MonoBehaviour
{
    #region // Referencias y elementos
    [Tooltip("Si es true la puerta no se puede usar")]
    public bool Locked = false;
    [Tooltip("True si se controla con palanca")]
    public bool Remote = false;
    [Space]
    public bool CanOpen = true;
    public bool CanClose = true;
    [Space]
    public bool RedLocked = false;
    public bool BlueLocked = false;
    [Tooltip("Conectar al jugador")]
    Jugador Jugador;
    [Space]
    public bool isOpened = false;
    [Range(0f, 4f)]
    public float OpenSpeed = 3f;

    float distance;
    float angleView;
    Vector3 direction;

    Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;

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

    #region //Apertura con llaves
    public void Action()
    {
        if (!Locked)
        {
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

            if (isOpened && CanClose && !RedLocked && !BlueLocked)
            {
                isOpened = false;
            }
            else if (!isOpened && CanOpen && !RedLocked && !BlueLocked)
            {
                isOpened = true;
            }
        }
    }
    #endregion
    bool NearView()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return distance < 3f;
    }

    private void FixedUpdate()
    {
        hingeLim = hinge.limits; // Obtener los límites actuales

        if (isOpened)
        {
            hingeLim.max = 90f; // Ángulo máximo de apertura
            hingeLim.min = 0f;
        }
        else
        {
            hingeLim.max = 0f;  // Cerrar completamente
            hingeLim.min = 0f;
        }

        hinge.limits = hingeLim; // Aplicar límites actualizados

        Quaternion targetRotation = isOpened ? Quaternion.Euler(0, 90f, 0) : Quaternion.Euler(0, 0, 0);
        rbDoor.MoveRotation(Quaternion.Lerp(rbDoor.rotation, targetRotation, Time.fixedDeltaTime * OpenSpeed));
    }
}
