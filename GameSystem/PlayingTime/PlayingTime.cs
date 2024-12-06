using System.Collections;
using UnityEngine;

public class PlayingTime : MonoBehaviour
{
    public int hours;
    public int minutes;
    public int seconds;

    private Coroutine clock;
    private const int MAX_HOURS = 999;

    // TODO: Update hoursr, minutes and seconds from JSON file.

    // Update is called once per frame
    void Update()
    {
        if (clock != null)
        {
            clock = StartCoroutine(UpdateClock());
        }
    }

    /// <summary>
    /// Game internal clock coroutine.
    /// </summary>
    /// <returns>IEnumerator</returns>
    public IEnumerator UpdateClock()
    {
        seconds++;

        if (seconds > 59)
        {
            seconds = 0;
            minutes++;
        }

        if (minutes > 59)
        {
            minutes = 0;
            hours++;
        }

        yield return new WaitForSeconds(1f);
        clock = null;
    }

    /// <summary>
    /// Get play time in string format.
    /// </summary>
    /// <returns>string</returns>
    public string GetPlayedTimeString()
    {
        string hours = this.hours < 10 ? "0" + this.hours.ToString() : this.hours.ToString();
        string minutes = this.minutes < 10 ? "0" + this.minutes.ToString() : this.minutes.ToString();
        string seconds = this.seconds < 10 ? "0" + this.seconds.ToString() : this.seconds.ToString();

        return hours + ":" + minutes + ":" + seconds;
    }
}
