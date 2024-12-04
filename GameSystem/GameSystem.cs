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
    public PartyMembers partyMembers;
    public Inventory inventory;
    public Skills skills;
        
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
}
