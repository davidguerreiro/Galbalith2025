using UnityEngine;

/// <summary>
/// Conditional logic for boolean variables.
/// Checks whether all variables set in true variables and false variables
/// are set in true and false respectively. If conditions are met, returns true.
/// </summary>
public class BooleanVariableConditionalLogic : ConditionalLogic
{
    [Header("Variables")]
    public BooleanVars booleanVars;

    [Header("Conditions")]
    public string[] trueVariables;
    public string[] falseVariables;

    /// <summary>
    /// Perform can runner event be triggered operation.
    /// </summary>
    /// <returns>bool</returns>
    public override bool CanBeTriggered()
    {
        // check true variables.
        foreach (string trueVariable in trueVariables)
        {
            if (booleanVars.GetValue(trueVariable) == false)
            {
                return false;
            }
        }

        // check false variables.
        foreach (string falseVariable in falseVariables)
        {
            if (booleanVars.GetValue(falseVariable) ==  true)
            {
                return false;
            }
        }

        return true;
    }
}
