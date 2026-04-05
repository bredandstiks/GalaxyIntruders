using UnityEngine;

public class gameOverScript : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject darkness;

    void Start()
    {

    }

    void Update()
    {
        if (logicScript.dead)
        {
            winText.SetActive(false);
            loseText.SetActive(true);
            darkness.SetActive(true);
            Debug.Log("Dead");
        }
        else if (logicScript.enemiesLeft <= 0)
        {
            winText.SetActive(true);
            loseText.SetActive(false);
            darkness.SetActive(true);
        }
        else
        {
            loseText.SetActive(false);
        }
    }
}