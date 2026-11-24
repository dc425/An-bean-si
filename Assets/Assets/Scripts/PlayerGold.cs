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

    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + gold;
        }
    }
}