using System;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberWindow : MonoBehaviour
{
    [Header("Components")]
    public TextComponent memberName;
    public Image memberFace;
    public TextComponent hp;
    public Slider hpBar;
    public TextComponent mp;
    public Slider mpBar;
    public TextComponent level;
    public TextComponent exp;
    public Slider expBar;
    public Image[] statusImages;

    private PartyMember partyMember;
    private GameSystem gameSystem;

    public void Init(PartyMember partyMember, GameSystem gameSystem)
    {
        this.partyMember = partyMember;
        this.gameSystem = gameSystem;
    }

    public void Refresh(PartyMember partymember = null)
    {
        if (partymember != null)
        {
            this.partyMember = partymember;
        }

        if (this.partyMember != null)
        {
            RefreshFace();
            RefreshName();
            RefreshHP();
            RefreshMP();
            RefreshLevel();
            RefreshExpBar();
            RefreshStatus();
        }
    }

    /// <summary>
    /// Refresh party member face.
    /// </summary>
    public void RefreshFace()
    {
        if (memberFace != null)
        {
            memberFace.sprite = partyMember.GetMemberIcon();
        }
    }

    /// <summary>
    /// Refresh party member name.
    /// </summary>
    public void RefreshName()
    {
        if (memberName)
        {
            memberName.UpdateContent(partyMember.GetDisplayName());
        }
    }

    /// <summary>
    /// Refresh party member HP.
    /// </summary>
    public void RefreshHP()
    {
        if (hp)
        {
            hp.UpdateContent(partyMember.hp.ToString() + " / " + partyMember.maxHP.ToString());
        }

        if (hpBar)
        {
            hpBar.maxValue = partyMember.maxHP;
            hpBar.value = partyMember.hp;
        }
    }

    /// <summary>
    /// Refresh MP bar.
    /// </summary>
    public void RefreshMP()
    {
        if (mp)
        {
            mp.UpdateContent(partyMember.mp.ToString() + " / " + partyMember.maxMP.ToString());
        }

        if (mpBar)
        {
            mpBar.maxValue = partyMember.maxMP;
            mpBar.value = partyMember.mp;
        }

        
    }

    /// <summary>
    /// Refresh level text.
    /// </summary>
    /// <param name="includeLevelText"></param>
    public void RefreshLevel(bool includeLevelText = true)
    {
        string levelText = partyMember.level.ToString();

        if (includeLevelText)
        {
            levelText = "Lv." + levelText;
        }

        level.UpdateContent(levelText);
    }

    /// <summary>
    /// Refresh exp bar.
    /// </summary>
    public void RefreshExpBar()
    {
        if (exp)
        {
            exp.UpdateContent(partyMember.currentExp.ToString());
        }

        if (expBar)
        {
            expBar.maxValue = partyMember.nextLevelExp;
            expBar.value = partyMember.currentExp;
        }
    }

    /// <summary>
    /// Print status icon in player stats
    /// window.
    /// </summary>
    public void RefreshStatus()
    {
        if (statusImages.Length > 0)
        {
            // remove previous icons.
            foreach (Image iconImage in statusImages)
            {
                iconImage.gameObject.SetActive(false);
            }

            // print status in player screen.
            foreach (string statusConditionID in partyMember.statusCondition)
            {
                if (statusConditionID != "")
                {
                    StatusCondition statusCondition = gameSystem.GetStatusCondition(statusConditionID);
                    Image statusIconImage = Array.Find(statusImages, (statusImage => statusImage.gameObject.activeSelf == false));

                    if (statusIconImage != null)
                    {
                        statusIconImage.gameObject.SetActive(true);
                        statusIconImage.sprite = statusCondition.icon;
                    }
                }
            }
        }
    }
    
}