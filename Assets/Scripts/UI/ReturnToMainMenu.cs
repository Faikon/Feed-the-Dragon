using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene(ScenesNames.MainMenu.ToString());
        Time.timeScale = 1.0f;
    }
}
