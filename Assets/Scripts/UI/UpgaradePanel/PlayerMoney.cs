using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public void AddMoney(int money)
    {
        int currentMoney = PlayerPrefs.GetInt(PlayerKeys.Money.ToString());

        PlayerPrefs.SetInt(PlayerKeys.Money.ToString(), currentMoney + money);
    }

    public bool TrySpendMoney(int money)
    {
        int currentMoney = PlayerPrefs.GetInt(PlayerKeys.Money.ToString());

        if (money <= currentMoney)
        {
            currentMoney -= money;

            PlayerPrefs.SetInt(PlayerKeys.Money.ToString(), currentMoney);

            return true;
        }

        return false;
    }    
}
