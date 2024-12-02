using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [Header("Data")]
    public PartyMemberData staticData;

    // TODO: Add stats level/base stats data array here.
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
    public int speed;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
