using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player2DMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;
    private Vector3 moveDir;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDir.magnitude > 0)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        // Enviar valores al Animator
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveZ", moveZ);
    }
}
