using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringBoolPair
{
    public string key;
    public bool value;
}

public class BooleanVars : MonoBehaviour
{
    [SerializeField]
    private List<StringBoolPair> variables = new List<StringBoolPair>();

    private Dictionary<string, bool> runTimeVariables;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDictionary();
    }

    /// <summary>
    /// Generates dictionary of variables.
    /// </summary>
    private void GenerateDictionary()
    {
        runTimeVariables = new Dictionary<string, bool>();

        foreach (StringBoolPair variable in variables)
        {
            runTimeVariables[variable.key] = variable.value;                
        }
    }

    /// <summary>
    /// Update variable value.
    /// </summary>
    /// <param name="key">string</param>
    /// <param name="value">bool</param>
    public void UpdateVariable(string key, bool value)
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
    /// <param name="key">string</param>
    /// <returns>bool</returns>
    public bool GetValue(string key)
    {
        if (runTimeVariables.TryGetValue(key, out bool value))
        {
            return value;
        }

        return false;
    }
}
