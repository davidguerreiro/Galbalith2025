using UnityEngine;

[CreateAssetMenu(fileName = "StatsData", menuName = "Scriptable Objects/PartyMember/StatsData")]

/**
 * Defines stats data class.
 * 
 * This is used to get a stat value by level.
 * 
 * The index is the current party member level.
 */
public class StatsData : ScriptableObject
{
    public int[] stats = new int[99];

    /// <summary>
    /// Get value filtered by party member level.
    /// </summary>
    /// <param name="level"></param>
    /// <returns>int</returns>
    public int GetValue(int level)
    {
        return stats[level];
    }

}
