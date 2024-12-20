using UnityEngine;

public class Gold : MonoBehaviour
{
    public int gold;

    private const int MAX_GOLD = 99999;

    // TOOD: Read gold value from JSON.
    
    /// <summary>
    /// Update gold.
    /// </summary>
    /// <param name="value"></param>
    public void UpdateGold(int value)
    {
        gold += value;

        if (gold < 0)
        {
            gold = 0;
        }

        if (gold > MAX_GOLD)
        {
            gold = MAX_GOLD;
        }
    }

    /// <summary>
    /// Get gold as string text.
    /// </summary>
    /// <param name="includeGoldText">bool</param>
    /// <returns>string</returns>
    public string GetGoldString(bool includeGoldText = true)
    {
        string goldText = gold.ToString();

        if (includeGoldText)
        {
            goldText += " Pesetas";
        }

        return goldText;
    }
}
