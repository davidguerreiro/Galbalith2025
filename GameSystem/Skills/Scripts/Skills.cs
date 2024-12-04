using System;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public Skill[] magic;
    public Skill[] active;
    public Skill[] passive;

    /// <summary>
    /// Get magic from magic reference list.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>Skill</returns>
    public Skill GetMagicSkill(string id)
    {
        return Array.Find(magic, (magic => magic.data.id == id));
    }

    /// <summary>
    /// Get active skill from active skills list
    /// reference.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Skill</returns>
    public Skill GetActiveSkill(string id)
    {
        return Array.Find(active, (skill => skill.data.id == id));
    }

    /// <summary>
    /// Get passive skill from passive skills list
    /// reference.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Skill</returns>
    public Skill GetPassiveSkill(string id)
    {
        return Array.Find(passive, (skill => skill.data.id == id));
    }
}
