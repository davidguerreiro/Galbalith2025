using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableData", menuName = "Scriptable Objects/Items/ConsumableData")]
public class ConsumableData : ScriptableObject
{
    public enum Scope
    {
        allies,
        enemies,
        all,
    };

    public enum DamageType
    {
        physical,
        magical,
    };

    public string id;
    public string displayNameEn;
    public string displayNameEs;
    public Sprite icon;
    public AudioClip useSound;

    [TextArea(5, 99)]
    public string descriptionEn;
    [TextArea(5, 99)]
    public string descriptionEs;

    [Space(10)]

    [Header("Trade Settings")]
    public int price;
    public bool sellable;

    [Space(10)]

    [Header("Healing Effects")]
    public int hpRecoveredValue;
    public bool fullHealHp;
    public int mpRecoveredValue;
    public bool fullHealMp;

    [Space(10)]

    [Header("Remove Status")]
    public bool removeAllStatusCondition;
    public StatusCondition[] statusToRemove;

    [Space(10)]

    [Header("Damage Effects")]
    public int basePower;
    public float variation;
    public Elements element;
    public Scope scope;
    public DamageType damageType;

    [Space(10)]

    [Header("Other options")]
    public bool usableInMenu;
    public bool usableInBattle;
    public bool keyItem;
    public bool ignoreDefense;
}
