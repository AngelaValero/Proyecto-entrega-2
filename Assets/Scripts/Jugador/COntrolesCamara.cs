using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COntrolesCamara : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f; // Sensibilidad del ratón
    [SerializeField] Transform playerBody;         // Referencia al cuerpo del jugador
    private float xRotation = 0f;                  // Control de la rotación vertical de la cámara

    void Start()
    {
        // Bloquear y ocultar el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Capturar el movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical (eje X)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación para evitar voltear completamente

        // Aplicar la rotación
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Cámara rota verticalmente
        playerBody.Rotate(Vector3.up * mouseX); // Rotar el cuerpo del jugador horizontalmente
    }
}
