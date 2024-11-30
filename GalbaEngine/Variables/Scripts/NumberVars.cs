using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringNumberPair
{
    public string key;
    public int value;
}

public class NumberVars : MonoBehaviour
{
    private List<StringNumberPair> variables = new List<StringNumberPair>();

    private Dictionary<string, int> runTimeVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDictionary();
    }

    /// <summary>
    /// Generate dictionary of varibles.
    /// </summary>
    private void GenerateDictionary()
    {
        runTimeVariables = new Dictionary<string, int>();

        foreach (StringNumberPair variable in variables)
        {
            runTimeVariables[variable.key] = variable.value;
        }
    }

    /// <summary>
    /// Update variable value.
    /// </summary>
    /// <param name="key">string</param>
    /// <param name="value">int</param>
    public void UpdateVariable(string key, int value)
    {
        try
        {
            runTimeVariables[key] = value;
        } catch (KeyNotFoundException error)
        {
            Debug.Log("Key not found when updating variable" + error);
        }
    }

    /// <summary>
    /// Get variable current value.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>int</returns>
    public int GetValue(string key)
    {
        if (runTimeVariables.TryGetValue(key, out int value))
        {
            return value;
        }

        return 0;
    }

}
