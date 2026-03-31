using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public InputActionReference moveLeft;
    public InputActionReference moveRight;
    public float speed = 1;
    public Animator anim;
    public SpriteRenderer sr;
    public Sprite idleSprite;
    public GameObject laser;

    private float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if(sr.sprite.name == "Frame_6")
        {
            anim.speed = 0;
            sr.sprite = idleSprite;
        }
        

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
        Instantiate(laser, transform.position, transform.rotation);
        Debug.Log("Shoot");
    }
}
