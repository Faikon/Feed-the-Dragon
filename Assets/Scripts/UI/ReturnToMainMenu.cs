using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void Return()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene(ScenesNames.MainMenu.ToString());
    }
}
