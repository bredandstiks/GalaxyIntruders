using UnityEngine;
using UnityEngine.InputSystem;

public class playerInput : MonoBehaviour
{
    public InputActionReference moveLeft;
    public InputActionReference moveRight;
    public float speed = 1;
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
        if (moveLeft.action.IsPressed() && transform.position.x >= -1.77)
        {
            transform.position += Vector3.left * moveSpeed;
        }
        if (moveRight.action.IsPressed() && transform.position.x <= 1.9)
        {
            transform.position += Vector3.right * moveSpeed;
        }
    }

    private void OnShoot()
    {
        if (canShoot)
        {
            

            Instantiate(laser, new Vector3(transform.position.x, transform.position.y + laserOffset, transform.position.z), transform.rotation);
        }
        canShoot = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
            logicScript.dead = true;
        }
    }
}
