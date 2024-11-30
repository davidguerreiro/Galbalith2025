using System.Collections;
using UnityEngine;

/// <summary>
/// 
/// Main Engine class to process events.
/// 
/// Events contains all EventCommands runners. Event evaluate if all their EventCommands assigned
/// are ready to be run and, if so, runs the first one available in the stack.
/// 
/// An EventCommands only run if conditions are met, from first to last. The firs one that meet conditions is
/// run.
/// 
/// The EventCommands contains and run the commands one by one if the conditions to run are met.
/// 
/// Trigger logic defines when and how an event is triggered.
/// 
/// </summary>
public class Event : MonoBehaviour
{
    [Header("Event Commands")]
    public EventCommands[] eventCommands;

    [Space(10)]

    [Header("Options")]
    public bool walkingAnim;
    public bool directionFix;
    public bool ignorePhysics;

    [Space(10)]

    [HideInInspector]
    public Coroutine moveCoroutine;

    public enum Trigger
    {
        ActionButton,
        OnTouch,
        OnTouchLookingAt,
        Auto,
    };

    [Header("Trigger Logic")]
    [SerializeField]
    private Trigger eventTrigger;

    [HideInInspector]
    public Coroutine runningEventCommands;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (eventTrigger == Trigger.Auto)
        {
            TriggerCommand();
        }
    }

    /// <summary>
    /// Trigger events commands that met the conditions
    /// to be triggered.
    /// </summary>
    public void TriggerCommand()
    {
        if (runningEventCommands == null)
        {
            runningEventCommands = StartCoroutine(TriggerEventRoutine());
        }
    }

    /// <summary>
    /// Trigger event commands routine.
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator TriggerEventRoutine()
    {
        EventCommands eventCommandsToTrigger = null;

        foreach (EventCommands eventCommand in eventCommands)
        {
            if (eventCommand.CanRun())
            {
                eventCommandsToTrigger = eventCommand;
                break;
            }
        }

        if (eventCommandsToTrigger ) 
        { 
            eventCommandsToTrigger.RunCommands();

            while (eventCommandsToTrigger.runningCommands != null)
            {
                yield return new WaitForFixedUpdate();
            }
        }

        runningEventCommands = null;
    }
}
