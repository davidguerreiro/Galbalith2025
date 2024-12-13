using System;
using UnityEngine;

/// <summary>
/// Main game system class. Keeps reference to each of the game systems that
/// compose the game core.
/// 
/// This is the first class to initialize. From here all the game loads.
/// 
/// This class does not destroys OnLoad.
/// 
/// -- Party members: Holds data and funcionality from each party members.
/// 
/// </summary>
public class GameSystem : MonoBehaviour
{
    [Header("Game System Components")]
    public PartyMembers partyMembers;
    public Inventory inventory;
    public Skills skills;
    public Gold gold;
    public PlayingTime playingTime;

    [Header("Game Progression Variables")]
    public BooleanVars mainQuestVars;
    public BooleanVars secondaryQuestVars;
    public BooleanVars chestsVars;
    public BooleanVars huntingVars;
    public BooleanVars otherVars;

    [Header("Game System Static Data")]
    public Elements[] elements;
    public StatusCondition[] statusConditions;
        
    private void Start()
    {
        InitGameSystem();
    }

    // TODO: Load data based in read JSON File.
    public void InitGameSystem()
    {
        // init party members
        partyMembers.InitPartyMembers();
    }

    /// <summary>
    /// Get element from elements static data.
    /// </summary>
    /// <param name="elementID">string</param>
    /// <returns>Elements</returns>
    public Elements GetElement(string id)
    {
        return Array.Find(elements, (element => element.id == id));
    }

    /// <summary>
    /// Get status codition from status condition
    /// static data.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>StatusCondition</returns>
    public StatusCondition GetStatusCondition(string id)
    {
        return Array.Find(statusConditions, (statusCondition => statusCondition.id == id));
    }
}
