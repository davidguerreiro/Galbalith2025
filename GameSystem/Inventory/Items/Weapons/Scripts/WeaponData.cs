using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Items/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum Type
    {
        oneHandSword,
        twoHandsSword,
        rod,
        axe,
        spear,
        bow,
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

    [Header("Elements")]
    public Elements element;

    [Header("Other options")]
    public float hitRatio;
}
