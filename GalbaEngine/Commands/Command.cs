using System.Collections;
using UnityEngine;

/// <summary>
/// Commands are all the actions assigned to an event. They control the flow of the game.
/// A command can be almost anything, from playing and displayin a dialogue to change the 
/// weapon of a battler or even start a battle with a group of enemies.
/// </summary>
public class Command : MonoBehaviour
{
    [HideInInspector]
    public Coroutine runningCommand;

    /// <summary>
    /// Execute command.
    /// </summary>
    public virtual void ExecuteCommand()
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
    public virtual IEnumerator ExecuteRoutineCommand()
    {
        runningCommand = null;
        yield break;
    }
}
