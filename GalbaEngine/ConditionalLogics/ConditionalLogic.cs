using UnityEngine;

public class ConditionalLogic : MonoBehaviour
{
    /// <summary>
    /// Defines if a event commands runner can
    /// be triggered.
    /// </summary>
    /// <returns>bool</returns>
    public virtual bool CanBeTriggered()
    {
        return true;
    }
}
