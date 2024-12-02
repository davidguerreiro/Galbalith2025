using UnityEngine;

[CreateAssetMenu(fileName = "PartyMemberData", menuName = "Scriptable Objects/PartyMember/PartyMemberData")]
public class PartyMemberData : ScriptableObject
{
    [Header("Base Settings")]
    public string id;
    public string displayName;

    [Space(10)]

    public Sprite faceSprite;
}
