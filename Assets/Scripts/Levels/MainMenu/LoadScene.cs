using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1.0f;
    }
}
