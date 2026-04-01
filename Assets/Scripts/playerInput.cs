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
    public float laserOffset = 10f;
    public float cooldownTime = 1f;
    public logicScript logic;

    private float moveSpeed;
    private bool canShoot = true;
    private float cooldownTimer;

    void Start()
    {
        cooldownTimer = cooldownTime;
    }

    void Update()
    {
        if(sr.sprite.name == "Frame_6")
        {
            anim.speed = 0;
            sr.sprite = idleSprite;
        }

        if(!canShoot)
        {
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0)
            {
                canShoot = true;
                cooldownTimer = cooldownTime;
            }
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
        if (canShoot)
        {
            anim.speed = 1;
            anim.Play("playerShootAnim", 0, 1f);

            Instantiate(laser, new Vector3(transform.position.x, transform.position.y + laserOffset, transform.position.z), transform.rotation);
        }
        canShoot = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            // add score here
            Destroy(gameObject);
        }
    }
}
