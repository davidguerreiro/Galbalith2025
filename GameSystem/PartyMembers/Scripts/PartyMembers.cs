using UnityEngine;

public class PartyMembers : MonoBehaviour
{
    private const int maxPartyMembers = 3;

    public PartyMember[] partyMembers = new PartyMember[maxPartyMembers];

    public bool[] partyMembersMemory = new bool[maxPartyMembers];


    /// <summary>
    /// Add party member.
    /// </summary>
    /// <param name="listKey">int</param>
    public void AddPartyMember(int listKey)
    {
        if (partyMembers[listKey])
        {
            partyMembers[listKey].gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Remove party member.
    /// </summary>
    /// <param name="listKey"></param>
    public void RemovePartyMember(int listKey)
    {
        if (partyMembers[listKey])
        {
            partyMembers[listKey].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Get party member.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>PartyMember</returns>
    public PartyMember GetPartyMember(string id)
    {
        foreach (PartyMember partyMember in partyMembers)
        {
            if (partyMember && partyMember.GetID() == id)
            {
                return partyMember;
            }
        }

        return null;
    }

    /// <summary>
    /// Init party members.
    /// </summary>
    public void InitPartyMembers()
    {
        for (int i = 0; i < partyMembersMemory.Length; i++)
        {
            if (partyMembersMemory[i])
            {
                AddPartyMember(i);
            }
            else
            {
                RemovePartyMember(i);
            }
        }
    }
}
