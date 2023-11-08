using UnityEngine;

public class GiveCrystals : MonoBehaviour
{
    [SerializeField] private int _crystals;

    private void Start()
    {
        int money = PlayerPrefs.GetInt(PlayerKeys.Money.ToString());

        PlayerPrefs.SetInt(PlayerKeys.Money.ToString(), money + _crystals);
    }
}
