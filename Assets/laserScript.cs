using UnityEngine;

public class laserScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float darkValue = 0.95f;
    public int timeReq = 200;
    public float speed = 5;

    private float dms;
    private float timer = 0;
    private bool bright = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dms = Time.deltaTime * 1000;
        if (timer >= timeReq)
        {
            if (bright)
            {
                sprite.color = new Color(darkValue, darkValue, darkValue, sprite.color.a);
                bright = false;
            }
            else
            {
                sprite.color = new Color(1, 1, 1, sprite.color.a);
                bright = true;
            }
        }
        else
        {
            timer += dms;
        }

        transform.position += Vector3.up * Time.deltaTime * speed;

        if(transform.position.y >= 4)
        {
            Destroy(gameObject);
        }
    }
}
