using UnityEngine;

public class Consumable : MonoBehaviour
{
    public ConsumableData data;

    // TODO: Add inventory reference.

    /// <summary>
    /// Use consumable.
    /// </summary>
    /// <param name="partyMember">Partymember</param>
    public void Use (PartyMember partyMember)
    {
        // Heal HP.
        int hpToHeal = data.fullHealHp ? 9999 : data.hpRecoveredValue;
        partyMember.UpdateHP(hpToHeal);

        // Heal MP.
        int mpToHeal = data.fullHealMp ? 9999 : data.mpRecoveredValue;
        partyMember.UpdateMP(mpToHeal);

        // Heal status conditions.
        if (data.removeAllStatusCondition)
        {
            partyMember.RemoveAllStatusConditions();
        } else
        {
            foreach (StatusCondition statusCondition in data.statusToRemove)
            {
                partyMember.RemoveStatusCondition(statusCondition.id);
            }
        }
    }
}
