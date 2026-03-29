using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum enemyType { 
        level1, 
        level2, 
        level3
    }

    public enemyType type;

    private float timer = 0;
    public float baseTime = 4;
    public float level = 0;
    public float levelMult = 0.2f;
    public float levelTime;

    public GameObject laser;
// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTime = baseTime - (level * levelMult);
        if(timer >= levelTime)
        {
            timer = 0;
            Instantiate(laser, transform.position, Quaternion.Euler(0, 0, 180));
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            // add score here
            Destroy(gameObject);
        }
    }
}
