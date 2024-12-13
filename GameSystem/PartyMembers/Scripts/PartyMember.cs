using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SkillItem
{
    public string id;
    public int sp;
    public bool available;
    public bool learned;
    public bool enabled;
}

[System.Serializable]
public class ElementResistance
{
    public string id;
    public float resistance;

    private const float MAX_VALUE = 100f;
    private const float MIN_VALUE = -100f;

    /// <summary>
    /// Update resistance value.
    /// </summary>
    /// <param name="toAdd">float</param>
    public void UpdateResistance(float toAdd)
    {
        resistance += toAdd;

        if (resistance > MAX_VALUE)
        {
            resistance = MAX_VALUE;
        }

        if (resistance < MAX_VALUE)
        {
            resistance = MAX_VALUE;
        }
    }

    /// <summary>
    /// Sets resistance as damage absorbed.
    /// </summary>
    public void SetAbsorb()
    {
        resistance = -1f;
    }

    /// <summary>
    /// Restores resistance value.
    /// </summary>
    public void Clear()
    {
        resistance = 0f;
    }
}

public class PartyMember : MonoBehaviour
{
    [Header("Data")]
    public PartyMemberData staticData;

    [Header("Stats Data")]
    public StatsData hpData;
    public StatsData mpData;
    public StatsData attackData;
    public StatsData defenseData;
    public StatsData magicData;
    public StatsData agilityData;
    public StatsData nextLevelExpData;

    // TODO: Add read data from JSON File.

    [Space(10)]

    [Header("Level")]
    public int level;
    public int currentExp;
    public int nextLevelExp;

    [Header("Skill Points")]
    public int pointsUsed;
    public int skillPoints;

    [Space(10)]

    [Header("HP")]
    public int hp;
    public int maxHP;

    [Header("MP")]
    public int mp;
    public int maxMP;

    [Space(10)]

    [Header("Stats")]
    public int attack;
    public int defense;
    public int magic;
    public int agility;

    [Space(10)]
    public List<string> statusCondition = new List<string>(); 

    [Space(10)]

    [Header("Equipment")]
    public string weapon;
    public string shield;
    public string helmet;
    public string armor;
    public string accesory;

    [Space(10)]

    [Header("Skills")]

    [SerializeField]
    public List<SkillItem> magicSkills;

    [SerializeField]
    public List<SkillItem> activeSkills;

    [SerializeField]
    public List<SkillItem> passiveSkills;

    [Space(10)]

    [Header("Elemental Resistances")]
    public List<ElementResistance> elementsResistances = new List<ElementResistance>();

    [Space(10)]

    [Header("Component References")]
    public Inventory inventory;
    public Skills skills;


    private Weapon weaponRef;
    private Armor shieldRef;
    private Armor helmetRef;
    private Armor armorRef;
    private Armor accesoryRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set equipment reference.
        RefreshWeaponReference();
        RefreshShieldReference();
        RefreshHelmetReference();
        RefreshArmorReference();
        RefreshAccesoryReference();

        // Set stats.
        RefreshStats();
        InitHP();
        InitMP();

        // Set elemental resistances.
        ClearResistances();

        if (shieldRef != null)
        {
            CalculateElementResistances(shieldRef);
        }

        if (helmetRef != null)
        {
            CalculateElementResistances(helmetRef);
        }

        if (armorRef != null)
        {
            CalculateElementResistances(armorRef);
        }
        if (accesoryRef != null)
        {
            CalculateElementResistances(accesoryRef);
        }

    }

    /// <summary>
    /// Calculate max HP.
    /// </summary>
    private void CalculateMaxHP()
    {
        int baseHp = hpData.GetValue(level - 1);

        // TODO: Add skills increasers.

        baseHp += GetHPFromEquipment();

        maxHP = baseHp;
    }

    /// <summary>
    /// Calculate max MP
    /// </summary>
    private void CalculateMaxMP()
    {
        int baseMp = mpData.GetValue(level - 1);

        // TODO: Add skills increasers.

        baseMp += GetMPFromEquipment();

        maxMP = baseMp;
    }

    /// <summary>
    /// Calculate attack.
    /// </summary>
    private void CalculateAttack()
    {
        int baseAttack = attackData.GetValue(level - 1);

        // TODO: Add skills increasers.

        baseAttack += GetAttackFromEquipment();

        attack = baseAttack;
    }

    /// <summary>
    /// Calculate defense.
    /// </summary>
    private void CalculateDefense()
    {
        int baseDefense = defenseData.GetValue(level - 1);

        // TODO: Add skills increasers.

        baseDefense += GetDefenseFromEquipment();

        defense = baseDefense;
    }

    /// <summary>
    /// Calculate magic stat.
    /// </summary>
    private void CalculateMagic()
    {
        int baseMagic = magicData.GetValue(level - 1);

        // TODO: Add skills increasers.
        baseMagic += GetMagicFromEquipment();

        magic = baseMagic;
    }

    /// <summary>
    /// Calculate base agility.
    /// </summary>
    private void CalculateAgility()
    {
        int baseAgility = agilityData.GetValue(level - 1);

        // TODO: Add skills increasers.
        baseAgility += GetAgilityFromEquipment();

        agility = baseAgility;
    }

    /// <summary>
    /// Calculate next level exp.
    /// </summary>
    private void GetNextLevelExp()
    {
        nextLevelExp = nextLevelExpData.GetValue(level);
    }

    /// <summary>
    /// Refresh party member stats.
    /// Call this method every time equipment
    /// changes or level up.
    /// </summary>
    public void RefreshStats()
    {
        CalculateMaxHP();
        CalculateMaxMP();
        CalculateAttack();
        CalculateDefense();
        CalculateMagic();
        CalculateAgility();
        GetNextLevelExp();
    }

    /// <summary>
    /// Refresh weapon reference.
    /// </summary>
    public void RefreshWeaponReference()
    {
        if (weapon != "")
        {
            weaponRef = inventory.GetWeapon(weapon);
        }
        else 
        {
            weaponRef = null;
        }
    }

    /// <summary>
    /// Refresh shield reference.
    /// </summary>
    public void RefreshShieldReference()
    {
        if (shield != "")
        {
            shieldRef = inventory.GetArmor(shield);
        } else
        {
            shieldRef = null;
        }
    }

    /// <summary>
    /// Refresh helmet reference.
    /// </summary>
    public void RefreshHelmetReference()
    {
        if (helmet != "")
        {
            helmetRef = inventory.GetArmor(helmet);
        } else
        {
            helmetRef = null;
        }
    }

    /// <summary>
    /// Refresh armor reference.
    /// </summary>
    public void RefreshArmorReference()
    {
        if (armor != "")
        {
            armorRef = inventory.GetArmor(armor);
        } else
        {
            armorRef = null;
        }
    }

    /// <summary>
    /// Refresh accesory reference.
    /// </summary>
    public void RefreshAccesoryReference()
    {
        if (accesory != "")
        {
            accesoryRef = inventory.GetArmor(accesory);
        }
        else
        {
            accesoryRef = null;
        }
    }

    /// <summary>
    
    /// </summary>
    public void CalculateElementResistances(Armor armorItem)
    {
        // calculate resistances.
        foreach (Elements elementResists in armorItem.data.resists)
        {
            foreach (ElementResistance elementResistance in elementsResistances)
            {
                if (elementResistance.id == elementResists.id)
                {
                    elementResistance.UpdateResistance(20f);
                }
            }
        }

        // calculate weakness.
        foreach (Elements elementWeakness in armorItem.data.weakBy)
        {
            foreach (ElementResistance elementResistance in elementsResistances)
            {
                if (elementResistance.id == elementWeakness.id)
                {
                    elementResistance.UpdateResistance(-20f);
                }
            }
        }

        // calculate absorb.
        foreach (Elements elementAbsorb in armorItem.data.absorb)
        {
            foreach (ElementResistance elementResistance in elementsResistances)
            {
                if (elementResistance.id == elementAbsorb.id)
                {
                    elementResistance.SetAbsorb();
                }
            }
        }

    }

    /// <summary>
    /// Clear all resistances.
    /// </summary>
    public void ClearResistances()
    {
        foreach (ElementResistance elementResistance in elementsResistances)
        {
            elementResistance.Clear();
        }
    }

    /// <summary>
    /// Level party member up.
    /// </summary>
    public void LevelUp()
    {
        level++;

        // TEMP MAX LEVEL -- remove after prototype.
        if (level > 15)
        {
            level = 15;
        }

        RefreshStats();
    }

    /// <summary>
    /// Full heal party member.
    /// </summary>
    public void FullHeal()
    {
        hp = maxHP;
        mp = maxMP;

        // TODO: Remove stats.
    }

    /// <summary>
    /// Update HP value.
    /// </summary>
    /// <param name="value">int</param>
    public void UpdateHP(int value)
    {
        hp += value;

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp < 0)
        {
            hp = 0;
        }

        // TODO: Add K.0 status.
    }

    /// <summary>
    /// Update MP value.
    /// </summary>
    /// <param name="value">int</param>
    public void UpdateMP(int value)
    {
        mp += value;

        if (mp > maxMP)
        {
            mp = maxMP;
        }

        if (mp < 0)
        {
            mp = 0;
        }
    }

    /// <summary>
    /// Add status condition to party member.
    /// </summary>
    /// <param name="statusId"></param>
    public void AddStatusCondition(string statusId)
    {
        if (! statusCondition.Contains(statusId)) {
            statusCondition.Add(statusId);
        }
    }

    /// <summary>
    /// Remove status condition.
    /// </summary>
    /// <param name="statusId">string</param>
    public void RemoveStatusCondition(string statusId)
    {
        if (statusCondition.Contains(statusId))
        {
            statusCondition.Remove(statusId);
        }
    }

    /// <summary>
    /// Remove all status conditions.
    /// </summary>
    public void RemoveAllStatusConditions()
    {
        statusCondition.Clear();
    }

    /// <summary>
    /// Init HP value.
    /// </summary>
    public void InitHP()
    {
        hp = maxHP;

        // TODO: Read data from JSON File when loading game.
    }

    /// <summary>
    ///  Init MP value.
    /// </summary>
    public void InitMP()
    {
        mp = maxMP;

        // TODO: Read data from JSON File when loading game.
    }

    /// <summary>
    /// Get party member ID.
    /// </summary>
    /// <returns>int</returns>
    public string GetID()
    {
        return staticData.id;
    }

    /// <summary>
    /// Get party member Display Name.
    /// </summary>
    /// <returns>string</returns>
    public string GetDisplayName()
    {
        return staticData.displayName;
    }

    /// <summary>
    /// Get party member face sprite.
    /// </summary>
    /// <returns>Sprite</returns>
    public Sprite GetMemberIcon()
    {
        return staticData.faceSprite;
    }

    /// <summary>
    /// Equip Weapon.
    /// </summary>
    /// <param name="weapon">string</param>
    public void EquipWeapon(string weapon)
    {
        if (this.weapon != "")
        {
            DisableWeaponSkills(this.weapon);
        }

        this.weapon = weapon;
        RefreshWeaponReference();
        RefreshStats();
        ActiveWeaponSkills(weapon);
    }

    /// <summary>
    /// Remove weapon.
    /// </summary>
    public void RemoveWeapon()
    {
        if (this.weapon != "")
        {
            DisableWeaponSkills(this.weapon);
        }

        this.weapon = "";
        RefreshWeaponReference();
        RefreshStats();
    }

    /// <summary>
    /// Equip shield.
    /// </summary>
    /// <param name="shield">string</param>
    public void EquipShield(string shield)
    {
        if (this.shield != "")
        {
            DisableArmorSkills(this.shield);
        }

        this.shield = shield; 
        RefreshShieldReference();
        RefreshStats();
        ActiveWeaponSkills(shield);
    }

    /// <summary>
    /// Remove shield.
    /// </summary>
    public void RemoveShield()
    {
        if (this.shield != "")
        {
            DisableArmorSkills(this.shield);
        }

        this.shield = "";
        RefreshShieldReference();
        RefreshStats();
    }

    /// <summary>
    /// Equip helmet.
    /// </summary>
    /// <param name="helmet">string</param>
    public void EquipHelmet(string helmet)
    {
        this.helmet = helmet;
        RefreshHelmetReference();
        RefreshStats();
    }

    /// <summary>
    /// Remove helmet.
    /// </summary>
    public void RemoveHelmet()
    {
        this.helmet = "";
        RefreshHelmetReference();
        RefreshStats();
    }

    /// <summary>
    /// Equip armor.
    /// </summary>
    /// <param name="armor">string</param>
    public void EquipArmor(string armor)
    {
        this.armor = armor;
        RefreshArmorReference();
        RefreshStats();
    }

    /// <summary>
    /// Remove armor.
    /// </summary>
    public void RemoveArmor()
    {
        this.armor = "";
        RefreshArmorReference();
        RefreshStats();
    }

    /// <summary>
    /// Equip accessory.
    /// </summary>
    /// <param name="accesory">string</param>
    public void EquipAccesory(string accesory)
    {
        this.accesory = accesory;
        RefreshAccesoryReference();
        RefreshStats();
    }

    /// <summary>
    /// Remove accesory.
    /// </summary>
    public void RemoveAccesory()
    {
        this.accesory = "";
        RefreshAccesoryReference();
        RefreshStats();
    }

    /// <summary>
    /// Make weapon skills available when equiping weapon.
    /// </summary>
    /// <param name="id">string</param>
    public void ActiveWeaponSkills(string id)
    {
        Weapon weapon = inventory.GetWeapon(id);

        if (weapon != null)
        {
            // active magic skills.
            foreach (Skill skillRef in weapon.data.magicSkills)
            {
                SkillItem magic = HasMagic(skillRef.data.id);

                if (magic != null)
                {
                    magic.available = true;
                }
            }

            // active active skills.
            foreach (Skill skillRef in weapon.data.activeSkills)
            {
                SkillItem active = HasActive(skillRef.data.id);

                if (active != null)
                {
                    active.available = true;
                }
            }

            // active passive skills.
            foreach (Skill skillRef in weapon.data.passiveSkills)
            {
                SkillItem passive = HasPassive(skillRef.data.id);

                if (passive != null)
                {
                    passive.available = true;
                }
            }
        }
    }

    /// <summary>
    /// Hide unlearned weapon skills when unequiping weapon.
    /// </summary>
    /// <param name="id">string</param>
    public void DisableWeaponSkills(string id)
    {
        Weapon weapon = inventory.GetWeapon(id);

        if (weapon != null)
        {
            // hide magic skills.
            foreach (Skill skillRef in weapon.data.magicSkills)
            {
                SkillItem magic = HasMagic(skillRef.data.id);

                if (magic != null && ! magic.learned)
                {
                    magic.available = false;
                }
            }

            // hide active skills.
            foreach (Skill skillRef in weapon.data.activeSkills)
            {
                SkillItem active = HasActive(skillRef.data.id);

                if (active != null && ! active.learned)
                {
                    active.available = false;
                }
            }

            // hide passive skills.
            foreach (Skill skillRef in weapon.data.passiveSkills)
            {
                SkillItem passive = HasPassive(skillRef.data.id);

                if (passive != null && ! passive.learned)
                {
                    passive.available = false;
                }
            }
        }
    }

    /// <summary>
    /// Make availble skills when equiping armor.
    /// </summary>
    /// <param name="id">string</param>
    public void ActivateArmorSkills(string id)
    {
        Armor armor = inventory.GetArmor(id);

        if (armor != null)
        {
            // active magic skills.
            foreach (Skill skillRef in armor.data.magicSkills)
            {
                SkillItem magic = HasMagic(skillRef.data.id);

                if (magic != null)
                {
                    magic.available = true;
                }
            }

            // active active skills.
            foreach (Skill skillRef in armor.data.activeSkills)
            {
                SkillItem active = HasActive(skillRef.data.id);

                if (active != null)
                {
                    active.available = true;
                }
            }

            // active passive skills.
            foreach (Skill skillRef in armor.data.passiveSkills)
            {
                SkillItem passive = HasPassive(skillRef.data.id);

                if (passive != null)
                {
                    passive.available = true;
                }
            }
        }
    }

    /// <summary>
    /// Hide unlearned skills when removind armor priece from
    /// equipment.
    /// </summary>
    /// <param name="id">string</param>
    public void DisableArmorSkills(string id)
    {
        Armor armor = inventory.GetArmor(id);

        if (armor != null)
        {
            // hide magic skills.
            foreach (Skill skillRef in armor.data.magicSkills)
            {
                SkillItem magic = HasMagic(skillRef.data.id);

                if (magic != null && !magic.learned)
                {
                    magic.available = false;
                }
            }

            // hide active skills.
            foreach (Skill skillRef in armor.data.activeSkills)
            {
                SkillItem active = HasActive(skillRef.data.id);

                if (active != null && !active.learned)
                {
                    active.available = false;
                }
            }

            // hide passive skills.
            foreach (Skill skillRef in armor.data.passiveSkills)
            {
                SkillItem passive = HasPassive(skillRef.data.id);

                if (passive != null && !passive.learned)
                {
                    passive.available = false;
                }
            }
        }
    }

    /// <summary>
    /// Get HP from equipment.
    /// </summary>
    /// <returns>int</returns>
    private int GetHPFromEquipment()
    {
        int weaponHp = weaponRef != null ? weaponRef.data.hp : 0;
        int shieldHp = shieldRef != null ? shieldRef.data.hp : 0;
        int helmetHp = helmetRef != null ? helmetRef.data.hp : 0;
        int armorHp = armorRef != null ? armorRef.data.hp : 0;
        int accesoryHp = accesoryRef != null ? accesoryRef.data.hp : 0;

        return weaponHp + shieldHp + helmetHp + armorHp + accesoryHp;
    }

    /// <summary>
    /// Get MP from equipment 
    /// </summary>
    /// <returns>int</returns>
    private int GetMPFromEquipment()
    {
        int weaponMp = weaponRef != null ? weaponRef.data.mp : 0;
        int shieldMp = shieldRef != null ? shieldRef.data.mp : 0;
        int helmetMp = helmetRef != null ? helmetRef.data.mp : 0;
        int armorMp = armorRef != null ? armorRef.data.mp : 0;
        int accesoryMp = accesoryRef != null ? accesoryRef.data.mp : 0;

        return weaponMp + shieldMp + helmetMp + armorMp + accesoryMp;
    }

    /// <summary>
    /// Get Attack from equipment.
    /// </summary>
    /// <returns>int</returns>
    private int GetAttackFromEquipment()
    {
        int weaponAttack = weaponRef != null ? weaponRef.data.attack : 0;
        int shieldAttack = shieldRef != null ? shieldRef.data.attack : 0;
        int helmetAttack = helmetRef != null ? helmetRef.data.attack : 0;
        int armorAttack = armorRef != null ? armorRef.data.attack : 0;
        int accesoryAttack = accesoryRef != null ? accesoryRef.data.attack : 0;

        return weaponAttack + shieldAttack + helmetAttack + armorAttack + accesoryAttack;
    }

    /// <summary>
    /// Get Defense from equipment.
    /// </summary>
    /// <returns>int</returns>
    private int GetDefenseFromEquipment()
    {
        int weaponDefense = weaponRef != null ? weaponRef.data.defense : 0;
        int shieldDefense = shieldRef != null ? shieldRef.data.defense : 0;
        int helmetDefense = helmetRef != null ? helmetRef.data.defense : 0;
        int armorDefense = armorRef != null ? armorRef.data.defense : 0;
        int accesoryDefense = accesoryRef != null ? accesoryRef.data.defense : 0;

        return weaponDefense + shieldDefense + helmetDefense + armorDefense + accesoryDefense;
    }

    /// <summary>
    /// Get Magic from equipment.
    /// </summary>
    /// <returns>int</returns>
    private int GetMagicFromEquipment()
    {
        int weaponMagic = weaponRef != null ? weaponRef.data.magic: 0;
        int shieldMagic = shieldRef != null ? shieldRef.data.magic : 0;
        int helmetMagic = helmetRef != null ? helmetRef.data.magic : 0;
        int armorMagic = armorRef != null ? armorRef.data.magic : 0;
        int accesoryMagic = accesoryRef != null ? accesoryRef.data.magic : 0;

        return weaponMagic + shieldMagic + helmetMagic + armorMagic + accesoryMagic;
    }

    /// <summary>
    /// Get agility from equipment.
    /// </summary>
    /// <returns>int</returns>
    private int GetAgilityFromEquipment()
    {
        int weaponAgility = weaponRef != null ? weaponRef.data.agility : 0;
        int shieldAgility = shieldRef != null ? shieldRef.data.agility : 0;
        int helmetAgility = helmetRef != null ? helmetRef.data.agility : 0;
        int armorAgility = armorRef != null ? armorRef.data.agility : 0;
        int accesoryAgility = accesoryRef != null ? accesoryRef.data.agility : 0;

        return weaponAgility + shieldAgility + helmetAgility + armorAgility + accesoryAgility;
    }

    /// <summary>
    /// Update skills sp at the end of battle.
    /// </summary>
    /// <param name="sp">int</param>
    public void UpdateSkillsSP(int sp)
    {
        // deliver sp points to magic skills.
        foreach (SkillItem magic in magicSkills)
        {
            if (magic.available && ! magic.learned)
            {
                Skill magicRef = skills.GetMagicSkill(magic.id);

                if (magicRef)
                {
                    magic.sp += sp;
                    CheckIfSkillLearned(magic, magicRef);
                }
            }
        }

        // deliver sp points to active skills.
        foreach (SkillItem active in activeSkills)
        {
            if (active.available && !active.learned)
            {
                Skill activeRef = skills.GetActiveSkill(active.id);

                if (activeRef)
                {
                    active.sp += sp;
                    CheckIfSkillLearned(active, activeRef);
                }
            }
        }

        // deliver sp points to passive skills.
        foreach (SkillItem passive in passiveSkills)
        {
            if (passive.available && ! passive.learned)
            {
                Skill passiveRef = skills.GetPassiveSkill(passive.id);

                if (passiveRef)
                {
                    passive.sp += sp;
                    CheckIfSkillLearned(passive, passiveRef);
                }
            }
        }
    }

    /// <summary>
    /// Check if skill is learned after
    /// getting sp.
    /// </summary>
    /// <param name="skillItem">SkillItem</param>
    /// <param name="skillReference">Skill</param>
    private void CheckIfSkillLearned(SkillItem skillItem, Skill skillReference)
    {
        if (skillItem.sp >= skillReference.data.spToLearn)
        {
            skillItem.learned = true;
        }
    }

    /// <summary>
    /// Enable skill. Enabling skills consume
    /// skill points.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool EnableSkill(string id)
    {
        SkillItem passive = HasPassive(id);

        if (passive != null)
        {
            if (pointsUsed < skillPoints && pointsUsed + 1 <= skillPoints)
            {
                passive.enabled = true;
                pointsUsed++;

                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Disable skill.
    /// </summary>
    /// <param name="id"></param>
    public void DisableSkill(string id)
    {
        SkillItem passive = HasPassive(id);

        if (passive != null && passive.enabled)
        {
            passive.enabled = false;
            pointsUsed--;

            if (pointsUsed < 0)
            {
                pointsUsed = 0;
            }
        }
    }

    /// <summary>
    /// Get Magic from list.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>SkillItem</returns>
    public SkillItem HasMagic(string id)
    {
        return magicSkills.Find(i => i.id == id);
    }

    /// <summary>
    /// Get Active skill from list.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>SkillItem</returns>
    public SkillItem HasActive(string id)
    {
        return activeSkills.Find(i => i.id == id);
    }

    /// <summary>
    /// Get passive skill.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>SkillItem</returns>
    public SkillItem HasPassive(string id)
    {
        return passiveSkills.Find(i => i.id == id);
    }

    /// <summary>
    /// Increase skill points available.
    /// </summary>
    /// <param name="increase"></param>
    public void IncreaseSkillPoints(int increase)
    {
        skillPoints += increase;
    }
    
    /// <summary>
    /// Set magic available, usually from changing equipment.
    /// </summary>
    /// <param name="id">string</param>
    public void SetMagicAvailable(string id)
    {
        SkillItem magic = HasMagic(id);

        if (magic != null)
        {
            magic.available = true;
        }
    }

    /// <summary>
    /// Set magic no available, usually from changing equipment.
    /// </summary>
    /// <param name="id">string</param>
    public void SetMagicUnavailable(string id)
    {
        SkillItem magic = HasMagic(id);

        if (magic != null)
        {
            if (! magic.learned)
            {
                magic.available = false;
            }
        }
    }

    /// <summary>
    /// Set active skill available.
    /// </summary>
    /// <param name="id">string</param>
    public void SetActiveAvailable(string id)
    {
        SkillItem active = HasActive(id);

        if (active != null)
        {
            active.available = true;
        }
    }

    /// <summary>
    /// Set active unavailable.
    /// </summary>
    /// <param name="id">string</param>
    public void SetActiveUnavailable(string id)
    {
        SkillItem active = HasActive(id);

        if (active != null)
        {
            if (!active.learned)
            {
                active.available = false;
            }
        }
    }

    /// <summary>
    /// Set passive available.
    /// </summary>
    /// <param name="id">string</param>
    public void SetPassiveAvailable(string id)
    {
        SkillItem passive = HasPassive(id);

        if (passive != null)
        {
            passive.available = true;
        }
    }

    /// <summary>
    /// Set active unavailable.
    /// </summary>
    /// <param name="id">string</param>
    public void SetPassiveUnavailable(string id)
    {
        SkillItem passive = HasPassive(id);

        if (passive != null)
        {

            if (!passive.learned)
            {
                if (passive.enabled)
                {
                    DisableSkill(id);
                }

                passive.available = false;
            }
        }
    }
}
