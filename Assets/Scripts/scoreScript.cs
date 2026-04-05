using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    public TextMeshProUGUI textobj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textobj.SetText("Score: {0}$", logicScript.score);
    }
}
