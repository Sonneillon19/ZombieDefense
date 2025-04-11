using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D o ← →
        float moveZ = Input.GetAxis("Vertical");   // W/S o ↑ ↓

        moveDirection = new Vector3(moveX, 0, moveZ);

        if (moveDirection.magnitude > 0.1f)
        {
            transform.forward = moveDirection; // Mira hacia donde se mueve
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
