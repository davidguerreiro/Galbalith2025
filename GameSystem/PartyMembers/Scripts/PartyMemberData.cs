using UnityEngine;

[CreateAssetMenu(fileName = "PartyMemberData", menuName = "Scriptable Objects/PartyMember/PartyMemberData")]
public class PartyMemberData : ScriptableObject
{
    [Header("Base Settings")]
    public string id;
    public string display_name_en;
    public string display_name_es;

    [Space(10)]

    public Sprite face_sprite;
}
