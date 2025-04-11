using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy3DController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float rotationSpeed = 720f;
    public float chaseRange = 10f;

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Mantener en plano XZ

        if (direction.magnitude < chaseRange)
        {
            Vector3 moveDir = direction.normalized;
            controller.Move(moveDir * moveSpeed * Time.deltaTime);

            Quaternion toRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Animación
            animator.SetFloat("MoveX", moveDir.x);
            animator.SetFloat("MoveZ", moveDir.z);
        }
        else
        {
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveZ", 0f);
        }
    }
}
