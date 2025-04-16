using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player3DController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D o ← →
        float moveZ = Input.GetAxis("Vertical");   // W/S o ↑ ↓

        Vector3 moveDir = new Vector3(moveX, 0, moveZ);

        if (moveDir.magnitude > 0.1f)
        {
            // Mover al jugador
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

            // Rotar hacia la dirección de movimiento
            Quaternion toRotation = Quaternion.LookRotation(moveDir.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Enviar al Animator (para Blend Tree)
        if (animator != null)
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveZ", moveZ);
        }
    }
}
