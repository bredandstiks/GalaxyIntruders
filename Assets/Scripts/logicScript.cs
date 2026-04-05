using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class logicScript : MonoBehaviour
{
    public static int score = 0;
    public static int enemiesLeft = 8 * 3;
    public static bool dead = false;

    private void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");
    }

    private void OnClose()
    {
        Application.Quit();
        Debug.Log("close");
    }
}
