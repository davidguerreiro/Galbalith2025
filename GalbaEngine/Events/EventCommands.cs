using System.Collections;
using UnityEngine;

/// <summary>
/// EventCommands holds and runs a sequent of commands assigned to this class.
/// 
/// First, it will check, in order, if all conditions to run the list of commands 
/// are met. If so, it runs the commands one by one.
/// 
/// Event Commands are always assigned to an Event.
/// </summary>
public class EventCommands : MonoBehaviour
{
    [Header("Run Conditions")]
    public ConditionalLogic[] conditions;

    [Space(10)]
    public Command[] commands;

    [HideInInspector]
    public Coroutine runningCommands;

    /// <summary>
    /// Checks if a group of event commands can be trigger.
    /// All conditions must be met in order to 
    /// trigger the list of events.
    /// </summary>
    /// <returns>bool</returns>
    public bool CanRun()
    {
        foreach (var condition in conditions)
        {
            if (condition.CanBeTriggered() == false)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Run all commands in this command runner.
    /// </summary>
    public void RunCommands()
    {
        if (runningCommands == null)
        {
            runningCommands = StartCoroutine(RunCommandsRoutine());
        }
    }

    /// <summary>
    /// Run all commmands in this event commands runner
    /// one by one.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator RunCommandsRoutine()
    {
        foreach (var command in commands)
        {
            command.ExecuteCommand();

            while (command.runningCommand != null)
            {
                yield return new WaitForFixedUpdate();
            }
        }

        runningCommands = null;
    }
}
