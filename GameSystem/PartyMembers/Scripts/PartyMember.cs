using System.Collections.Generic;
using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [Header("Data")]
    public PartyMemberData staticData;

    [Header("Stats Data")]
    public StatsData hpData;
    public StatsData mpData;
    public StatsData attackData;
    public StatsData defenseData;
    public StatsData magicData;
    public StatsData agilityData;
    public StatsData nextLevelExpData;

    // TODO: Add read data from JSON File.
    // TODO: Add Get current equipmnent.
    // TODO: Add equipment values to stats calculation.

    [Space(10)]

    [Header("Level")]
    public int level;
    public int currentExp;
    public int nextLevelExp;

    [Space(10)]

    [Header("HP")]
    public int hp;
    public int maxHP;

    [Header("MP")]
    public int mp;
    public int maxMP;

    [Space(10)]

    [Header("Stats")]
    public int attack;
    public int defense;
    public int magic;
    public int agility;

    [Space(10)]
    public List<string> statusCondition = new List<string>(); 

    [Space(10)]

    [Header("Equipment")]
    public string weapon;
    public string shield;
    public string helmet;
    public string armor;
    public string accesory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RefreshStats();
        InitHP();
        InitMP();
    }

    /// <summary>
    /// Calculate max HP.
    /// </summary>
    private void CalculateMaxHP()
    {
        int baseHp = hpData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        maxHP = baseHp;
    }

    /// <summary>
    /// Calculate max MP
    /// </summary>
    private void CalculateMaxMP()
    {
        int baseMp = mpData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        maxMP = baseMp;
    }

    /// <summary>
    /// Calculate attack.
    /// </summary>
    private void CalculateAttack()
    {
        int baseAttack = attackData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        attack = baseAttack;
    }

    /// <summary>
    /// Calculate defense.
    /// </summary>
    private void CalculateDefense()
    {
        int baseDefense = defenseData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        defense = baseDefense;
    }

    /// <summary>
    /// Calculate magic stat.
    /// </summary>
    private void CalculateMagic()
    {
        int baseMagic = magicData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        magic = baseMagic;
    }

    /// <summary>
    /// Calculate base agility.
    /// </summary>
    private void CalculateAgility()
    {
        int baseAgility = agilityData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        agility = baseAgility;
    }

    /// <summary>
    /// Calculate next level exp.
    /// </summary>
    private void GetNextLevelExp()
    {
        nextLevelExp = nextLevelExpData.GetValue(level);
    }

    /// <summary>
    /// Refresh party member stats.
    /// Call this method every time equipment
    /// changes or level up.
    /// </summary>
    public void RefreshStats()
    {
        CalculateMaxHP();
        CalculateMaxMP();
        CalculateAttack();
        CalculateDefense();
        CalculateMagic();
        CalculateAgility();
        GetNextLevelExp();
    }

    /// <summary>
    /// Level party member up.
    /// </summary>
    public void LevelUp()
    {
        level++;

        // TEMP MAX LEVEL -- remove after prototype.
        if (level > 15)
        {
            level = 15;
        }

        RefreshStats();
    }

    /// <summary>
    /// Full heal party member.
    /// </summary>
    public void FullHeal()
    {
        hp = maxHP;
        mp = maxMP;

        // TODO: Remove stats.
    }

    /// <summary>
    /// Update HP value.
    /// </summary>
    /// <param name="value">int</param>
    public void UpdateHP(int value)
    {
        hp += value;

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp < 0)
        {
            hp = 0;
        }

        // TODO: Add K.0 status.
    }

    /// <summary>
    /// Update MP value.
    /// </summary>
    /// <param name="value">int</param>
    public void UpdateMP(int value)
    {
        mp += value;

        if (mp > maxMP)
        {
            mp = maxMP;
        }

        if (mp < 0)
        {
            mp = 0;
        }
    }

    /// <summary>
    /// Add status condition to party member.
    /// </summary>
    /// <param name="statusId"></param>
    public void AddStatusCondition(string statusId)
    {
        if (! statusCondition.Contains(statusId)) {
            statusCondition.Add(statusId);
        }
    }

    /// <summary>
    /// Remove status condition.
    /// </summary>
    /// <param name="statusId">string</param>
    public void RemoveStatusCondition(string statusId)
    {
        if (statusCondition.Contains(statusId))
        {
            statusCondition.Remove(statusId);
        }
    }

    /// <summary>
    /// Remove all status conditions.
    /// </summary>
    public void RemoveAllStatusConditions()
    {
        statusCondition.Clear();
    }

    /// <summary>
    /// Init HP value.
    /// </summary>
    public void InitHP()
    {
        hp = maxHP;

        // TODO: Read data from JSON File when loading game.
    }

    /// <summary>
    ///  Init MP value.
    /// </summary>
    public void InitMP()
    {
        mp = maxMP;

        // TODO: Read data from JSON File when loading game.
    }

    /// <summary>
    /// Get party member ID.
    /// </summary>
    /// <returns>int</returns>
    public string GetID()
    {
        return staticData.id;
    }

    /// <summary>
    /// Get party member Display Name.
    /// </summary>
    /// <returns>string</returns>
    public string GetDisplayName()
    {
        return staticData.displayName;
    }

    /// <summary>
    /// Get party member face sprite.
    /// </summary>
    /// <returns>Sprite</returns>
    public Sprite GetMemberIcon()
    {
        return staticData.faceSprite;
    }

    /// <summary>
    /// Equip Weapon.
    /// </summary>
    /// <param name="weapon">string</param>
    public void EquipWeapon(string weapon)
    {
        this.weapon = weapon;
        RefreshStats();
    }

    /// <summary>
    /// Remove weapon.
    /// </summary>
    public void RemoveWeapon()
    {
        this.weapon = "";
        RefreshStats();
    }

    /// <summary>
    /// Equip shield.
    /// </summary>
    /// <param name="shield">string</param>
    public void EquipShield(string shield)
    {
        this.shield = shield;
        RefreshStats();
    }

    /// <summary>
    /// Remove shield.
    /// </summary>
    public void RemoveShield()
    {
        this.shield = "";
        RefreshStats();
    }

    /// <summary>
    /// Equip helmet.
    /// </summary>
    /// <param name="helmet">string</param>
    public void EquipHelmet(string helmet)
    {
        this.helmet = helmet;
        RefreshStats();
    }

    /// <summary>
    /// Remove helmet.
    /// </summary>
    public void RemoveHelmet()
    {
        this.helmet = "";
        RefreshStats();
    }

    /// <summary>
    /// Equip armor.
    /// </summary>
    /// <param name="armor">string</param>
    public void EquipArmor(string armor)
    {
        this.armor = armor;
        RefreshStats();
    }

    /// <summary>
    /// Remove armor.
    /// </summary>
    public void RemoveArmor()
    {
        this.armor = "";
        RefreshStats();
    }

    /// <summary>
    /// Equip accessory.
    /// </summary>
    /// <param name="accesory">string</param>
    public void EquipAccesory(string accesory)
    {
        this.accesory = accesory;
        RefreshStats();
    }

    /// <summary>
    /// Remove accesory.
    /// </summary>
    public void RemoveAccesory()
    {
        this.accesory = "";
        RefreshStats();
    }
}
