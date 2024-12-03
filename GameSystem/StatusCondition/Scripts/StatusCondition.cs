using UnityEngine;

[CreateAssetMenu(fileName = "StatusCondition", menuName = "Scriptable Objects/StatusCondition")]
public class StatusCondition : ScriptableObject
{
    public string id;
    public string displayNameEn;
    public string displayNameEs;

    public Sprite icon;

    [TextArea(4, 99)]
    public string descriptionEn;

    [TextArea(4, 99)]
    public string descriptionEs;

    public bool removedAfterBattle;
}
