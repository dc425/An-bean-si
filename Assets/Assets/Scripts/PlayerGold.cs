using UnityEngine;
using TMPro;

public class PlayerGold : MonoBehaviour
{
    public int gold = 0;
    public TMP_Text goldText;

    void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;

        UpdateGoldUI();

        Debug.Log("Gold: " + gold);
    }


    public int DepositAllGold()
    {
        int amount = gold;
        gold = 0;

        UpdateGoldUI();
        return amount;
    }

    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + gold;
        }
    }
}