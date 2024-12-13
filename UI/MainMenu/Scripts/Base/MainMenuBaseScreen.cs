using System;
using UnityEngine;

public class MainMenuBaseScreen : MainMenuScreen
{
    [Header("Main navegable")]
    public Navegable mainNavegable;

    [Header("PartyMembers")]
    public GameObject[] partyMemberSlots = new GameObject[3];

    [Header("Current MaP")]
    public TextComponent currentMap;

    [Header("Play Time")]
    public TextComponent currentPlayTime;

    [Header("Gold")]
    public TextComponent currentGold;

    private GameSystem gameSystem;
    private GameManager gameManager;

    private void Update()
    {
        if (gameSystem != null)
        {
            RefreshClock();
        }
    }

    /// <summary>
    /// Open base screen.
    /// </summary>
    /// <param name="mainMenu">MainMenu</param>
    /// <param name="gameSystem"></param>
    /// <param name="gameManager"></param>
    public override void Open(MainMenu mainMenu, GameSystem gameSystem = null, GameManager gameManager = null)
    {
        base.mainMenu = mainMenu;
        this.gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        this.gameManager = gameManager;


        InitMenu();

        Refresh();
    }

    /// <summary>
    /// Init main menu with items as menu
    /// focus item.
    /// </summary>
    public void InitMenu()
    {
        mainNavegable.SetNavegable();
        mainNavegable.SetSelectable("items");
    }

    /// <summary>
    /// Refresh data 
    /// </summary>
    public void Refresh()
    {
        // TODO: Add current map from levelManager;
        currentGold.UpdateContent(gameSystem.gold.GetGoldString());

        // Refresh party memebers data.
        RefreshPartyMembers();
    }

    /// <summary>
    /// Reload and draw party memebers list
    /// on screen.
    /// </summary>
    public void RefreshPartyMembers()
    {
        // disable all partymember slots.
        foreach (GameObject partyMemberSlot in partyMemberSlots)
        {
            if (partyMemberSlot)
            {
                partyMemberSlot.SetActive(false);
            }
        }

        foreach (PartyMember partyMember in gameSystem.partyMembers.partyMembers)
        {
            if (partyMember && partyMember.gameObject.activeSelf)
            {
                GameObject partyMemberSlot = Array.Find(partyMemberSlots, (partyMemberSlot => (partyMemberSlot.activeSelf == false)));

                partyMemberSlot.SetActive(true);

                PartyMemberWindow partyMemberWindow = partyMemberSlot.GetComponent<PartyMemberWindow>();
                partyMemberWindow.Init(partyMember, gameSystem);
                partyMemberWindow.Refresh();
            }
        }
    }

    /// <summary>
    /// Refresh clock play time data.
    /// </summary>
    public void RefreshClock()
    {
        currentPlayTime.UpdateContent(gameSystem.playingTime.GetPlayedTimeString());
    }

}
