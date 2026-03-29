using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public InputActionReference moveLeft;
    public InputActionReference moveRight;
    public float speed = 1;

    private float moveSpeed;

    private void Update()
    {
        moveSpeed = speed * Time.deltaTime;
        if (moveLeft.action.IsPressed() && transform.position.x >= -2)
        {
            transform.position += Vector3.left * moveSpeed;
        }
        if (moveRight.action.IsPressed() && transform.position.x <= 2)
        {
            transform.position += Vector3.right * moveSpeed;
        }
    }
}
