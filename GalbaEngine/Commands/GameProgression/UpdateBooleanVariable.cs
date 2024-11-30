using System.Collections;
using UnityEngine;

public class UpdateBooleanVariable : Command
{
    public BooleanVars variables;
    public string variableToUpdate;

    public enum Operation
    {
        setTrue,
        setFalse,
    };

    [Space(10)]
    [SerializeField]
    private Operation operation;

    /// <summary>
    /// Execute command.
    /// </summary>
    public override void ExecuteCommand()
    {
        if (runningCommand == null)
        {
            runningCommand = StartCoroutine(ExecuteRoutineCommand());
        }
    }

    /// <summary>
    /// Execute command routine.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public override IEnumerator ExecuteRoutineCommand()
    {
        switch (operation)
        {
            case Operation.setTrue:
                SetTrue();
                break;
            case Operation.setFalse:
                SetFalse();
                break;
            default:
                break;
        }

        runningCommand = null;
        yield break;
    }

    /// <summary>
    /// Set variable to true.
    /// </summary>
    private void SetTrue()
    {
        variables.UpdateVariable(variableToUpdate, true);
    }

    /// <summary>
    /// Set variable to false.
    /// </summary>
    private void SetFalse()
    {
        variables.UpdateVariable(variableToUpdate, false);
    }
}
