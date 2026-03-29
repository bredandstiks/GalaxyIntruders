using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public InputActionReference moveLeft;
    public InputActionReference moveRight;
    public float speed = 1;
    public Animator anim;

    private float moveSpeed;

    void Start()
    {
        
    }

    void Update()
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

    private void OnShoot()
    {
        anim.speed = 1;
        anim.Play("playerShootAnim", 0, 1f);
        anim.speed = 0;
    }
}
