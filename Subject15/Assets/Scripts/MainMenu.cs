using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadScene(string value)
    {
        SceneManager.LoadScene(value);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
