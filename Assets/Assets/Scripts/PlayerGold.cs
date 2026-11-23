
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    public int gold = 0;

    public void AddGold(int amount)
    {
        gold += amount;

        Debug.Log("Gold: " + gold);
    }
}
