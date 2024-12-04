using UnityEngine;

[CreateAssetMenu(fileName = "SkillsData", menuName = "Scriptable Objects/SkillsData")]
public class SkillsData : ScriptableObject
{
    public enum Type
    {
        magic,
        active,
        passive,
    };

    public enum Scope
    {
        itself,
        oneAlly,
        oneEnemy,
        allAlly,
        allEnemy,
    };

    public string id;
    public string displayNameEn;
    public string displayNameEs;
    public Sprite icon;

    [TextArea(5, 99)]
    public string descriptionEn;

    [TextArea(5, 99)]
    public string descriptionEs;

    [Space(10)]
    public Type type;
    public Elements element;

    [Space(10)]

    public int spToLearn;

    [Header("Battle Stats")]
    public int mpCost;
    public float hitRatio;
    public int basePower;
    public bool usePhysicalDamage;
    public GameObject battleAnim;

    [Space(10)]

    [Header("Scope")]
    public Scope scope;
    public bool usableInMenu;

    [Space(10)]

    [Header("Stauts changes")]
    public StatusCondition statusToAdd;
    public float chanceToAdd;
    public StatusCondition statusToRemove;
    public float chanceToRemove;

    [Header("Prevents Status")]
    public StatusCondition[] preventStuatusCondition;

}
