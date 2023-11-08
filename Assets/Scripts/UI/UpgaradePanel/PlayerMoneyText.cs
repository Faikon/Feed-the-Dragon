using TMPro;
using UnityEngine;

public class PlayerMoneyText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        SetText();
    }

    public void SetText()
    {
        _text.text = PlayerPrefs.GetInt(PlayerKeys.Money.ToString()).ToString();
    }
}
