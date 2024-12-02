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

    // TODO: Add exp required for next level data array here.

    [Space(10)]

    [Header("Level")]
    public int level;
    public int currentExp;
    public int nextLevelExp;

    [Space(10)]

    [Header("HP")]
    public int hp;
    public int maxHp;

    [Header("MP")]
    public int mp;
    public int maxMP;

    [Space(10)]

    [Header("Stats")]
    public int attack;
    public int defense;
    public int magic;
    public int agility;

    // TODO: Add status array.

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
    }

    /// <summary>
    /// Calculate max HP.
    /// </summary>
    private void CalculateMaxHP()
    {
        int baseHp = hpData.GetValue(level - 1);

        // TODO: Add items and skills increasers.

        maxHp = baseHp;
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

    public void FullHeal()
    {
        hp = maxHp;
        mp = maxMP;

        // TODO: Remove stats.
    }
}
