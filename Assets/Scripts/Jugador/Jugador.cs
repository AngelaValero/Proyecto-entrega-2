using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    #region //variables

    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 2f;

    private CharacterController jugador;
    private Vector3 velocity;
    private bool isGrounded;
    public AudioManager audioManager;
    public float daño;

    #endregion

    #region //controles jugador
    void Start()
    {
        jugador = GetComponent<CharacterController>();
    }

        void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = jugador.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Asegura que el personaje esté pegado al suelo
        }

        // Movimiento horizontal
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        jugador.Move(move * speed * Time.deltaTime);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        jugador.Move(velocity * Time.deltaTime);
    }
    #endregion


    #region //Interaccion con objetos

    [Tooltip("Are you have any key?")]
    public bool RedKey = false, BlueKey = false;
    [Tooltip("Child empty object for plug following")]
    public Transform GoalPosition;
}
    #endregion
