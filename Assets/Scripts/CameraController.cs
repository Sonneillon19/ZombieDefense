using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float minX = -10f;
    public float maxX = 20f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;
        position.x += horizontal * scrollSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }
}
