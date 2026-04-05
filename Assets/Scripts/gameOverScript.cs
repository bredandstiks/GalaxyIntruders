using UnityEngine;

public class gameOverScript : MonoBehaviour
{
    public GameObject winText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(logicScript.dead)
        {
            winText.SetActive(false);
            this.gameObject.SetActive(true);
        }
        else if(logicScript.enemiesLeft <= 0)
        {
            winText.SetActive(true);
            this.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(true);


    }
}
