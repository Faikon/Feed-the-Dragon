using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float Timer { get; private set; }

    private void Awake()
    {
        Timer = 0;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }
}
