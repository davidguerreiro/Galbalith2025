using System.Collections;
using UnityEngine;

public class PrintInConsoleCommand : Command
{
    public string toPrint;

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
        Debug.Log(toPrint);
        yield break;
        runningCommand = null;
    }
}
