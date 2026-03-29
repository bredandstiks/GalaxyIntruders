using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public int health = 4;
    public Sprite[] frames; // drag Frame_0 through Frame_3 in here in the Inspector

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        UpdateSprite();
        Debug.Log("Shield Hit, HP: " + health.ToString());
    }

    private void UpdateSprite()
    {
        int frameIndex = Invert(health, totalFrames);
        frameIndex = Mathf.Clamp(frameIndex, 0, frames.Length - 1);
        sr.sprite = frames[frameIndex];
    }

    private int Invert(int value, int max)
    {
        return max - value;
    }

    private int totalFrames => frames.Length;
}