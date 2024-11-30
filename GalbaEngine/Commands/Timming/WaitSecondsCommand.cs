using System.Collections;
using UnityEngine;

public class WaitSecondsCommand : Command
{
    public float secondsToWait;

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
        yield return new WaitForSeconds(secondsToWait);
        runningCommand = null;
    }
}
