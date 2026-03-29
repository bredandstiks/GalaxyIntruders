using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public int health = 4;
    public Animator anim;

    private const int totalFrames = 4;

    void Start()
    {
        anim.speed = 0;
    }

    void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        int frameIndex = Invert(health, totalFrames);
        anim.Play("shieldAnim", 0, (float)frameIndex / totalFrames);
        anim.speed = 0;
        Debug.Log("Shield Hit, HP: " + health.ToString());
    }

    private int Invert(int value, int max)
    {
        return max - value;
    }
}