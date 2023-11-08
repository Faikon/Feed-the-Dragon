using Agava.YandexGames;
using UnityEngine;

public class GameReady : MonoBehaviour
{
    private void Start()
    {
        YandexGamesSdk.GameReady();
    }
}
