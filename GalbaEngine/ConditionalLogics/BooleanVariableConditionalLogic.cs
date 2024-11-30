using UnityEngine;

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
