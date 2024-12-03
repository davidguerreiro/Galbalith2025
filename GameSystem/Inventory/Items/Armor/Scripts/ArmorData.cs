using UnityEngine;

[CreateAssetMenu(fileName = "ArmorData", menuName = "Scriptable Objects/Items/ArmorData")]
public class ArmorData : ScriptableObject
{
    public enum Type
    {
        shield,
        armor,
        helmet,
        accesory
    }

    public string id;
    public string displayNameEn;
    public string displayNameEs;
    public Sprite icon;
    public string modelName;

    [TextArea(5, 99)]
    public string descriptionEn;
    [TextArea(5, 99)]
    public string descriptionEs;

    [Space(10)]
    [Header("Armor type")]
    public Type type;

    [Header("Trade Settings")]
    public int price;
    public bool sellable;

    [Header("Parameters Changes")]
    public int hp;
    public int mp;
    public int attack;
    public int defense;
    public int magic;
    public int agility;

    [Header("Prevents Status")]
    public StatusCondition[] preventStuatusCondition;

    [Header("Elements")]
    public Elements[] resists;
    public Elements[] weakBy;

    [Header("Wield By")]
    public PartyMemberData[] wieldBy;
}
