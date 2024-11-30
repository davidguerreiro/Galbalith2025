using UnityEngine;

public class NumericVariableConditionalLogic : ConditionalLogic
{
    public NumberVars variables;
    public string variableToCheck;
    public int compareTo;

    public enum Condition
    {
        isLowerThan,
        isEqualTo,
        isHigherThan,
    };

    [Space(10)]
    [SerializeField]
    private Condition condition;

    /// <summary>
    /// Perform can runner event be triggered operation.
    /// </summary>
    /// <returns>bool</returns>
    public override bool CanBeTriggered()
    {
        int value = variables.GetValue(variableToCheck);

        switch (condition)
        {
            case Condition.isLowerThan:
                return isLowerThan(value);
            case Condition.isEqualTo:
                return isEqualTo(value);
            case Condition.isHigherThan:
                return isHigherThan(value);
            default:
                return false;
        }
    }

    /// <summary>
    /// Is lower than comparison.
    /// </summary>
    /// <param name="varValue">int</param>
    /// <returns>bool</returns>
    private bool isLowerThan(int varValue)
    {
        return varValue < compareTo;
    }

    /// <summary>
    /// Is Equal to comparison.
    /// </summary>
    /// <param name="varValue">int</param>
    /// <returns>bool</returns>
    private bool isEqualTo(int varValue)
    {
        return varValue == compareTo;
    }

    /// <summary>
    /// Is Higher than comparison.
    /// </summary>
    /// <param name="varValue">int</param>
    /// <returns>bool</returns>
    private bool isHigherThan(int varValue)
    {
        return varValue > compareTo;
    }
}
