using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum enemyType
    {
        level1,
        level2,
        level3
    }

    public enemyType type;

    private float timer = 0;
    public float baseTime;
    public float level = 0;
    public float levelMult = 0.2f;
    public float levelTime;

    public float moveSpeed = 1f;
    private float moveTime;
    private float moveTimer = 0;
    public float moveDistance = 10f;

    public GameObject laser;
    public float rayLength = 0.3f;

    private bool canShoot = true;

    void Start()
    {
        setBaseTime();
        setMoveTime();
    }

    void Update()
    {
        if (!logicScript.dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);
            Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);

            if (hit.collider != null && hit.collider.name.Contains("Enemy"))
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }

            levelTime = baseTime - (level * levelMult);
            if (timer >= levelTime && canShoot)
            {
                timer = 0;
                Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 180));
                setBaseTime();
            }
            else
            {
                timer += Time.deltaTime;
            }

            levelMult = 0.2f * level;

            if (moveTimer >= moveTime)
            {
                moveTimer = 0;
                transform.position = new Vector3(transform.position.x, transform.position.y - moveDistance, transform.position.z);
            }
            else
            {
                moveTimer += Time.deltaTime;
            }

            if(transform.position.y <= -1.5)
            {
                logicScript.dead = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            int scr = 0;
            switch (type)
            {
                case enemyType.level1:
                    scr = 100;
                    break;
                case enemyType.level2:
                    scr = 200;
                    break;
                case enemyType.level3:
                    scr = 300;
                    break;
            }

            logicScript.score += scr;
            logicScript.enemiesLeft -= 1;

            Destroy(gameObject);
        }
    }

    void setBaseTime()
    {
        baseTime = Random.Range(6f, 12f) - levelMult;
    }

    void setMoveTime()
    {
        moveTime = 6 - moveSpeed;
    }
}