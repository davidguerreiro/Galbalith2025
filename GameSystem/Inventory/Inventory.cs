using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryList
{
    public string id;
    public int quantity;
}

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public List<InventoryList> items;

    [SerializeField]
    public List<InventoryList> weapons;

    [SerializeField]
    public List<InventoryList> armors;

    public Consumable[] itemsReference;
    public Weapon[] weaponReference;
    public Armor[] armorReference;

    private const int MAX_QUANTITY = 99;

    /// <summary>
    /// Add item to the list.
    /// 
    /// If item exists, update item with stack 
    /// quantity.
    /// </summary>
    /// <param name="id">string</param>
    /// <param name="quantity">quantity</param>
    public void AddItem(string id, int quantity = 1)
    {
        InventoryList item = HasItem(id);

        if (item != null)
        {
            item.quantity += quantity;

            if (item.quantity > MAX_QUANTITY)
            {
                item.quantity = MAX_QUANTITY;
            }

            if (item.quantity <= 0)
            {
                RemoveItem(id);
            }
        } else
        {
            InventoryList newItem = new InventoryList();
            newItem.id = id;
            newItem.quantity = quantity;

            items.Add(newItem);
        }
    }

    /// <summary>
    /// Remove 
    /// </summary>
    /// <param name="id"></param>
    public void RemoveItem(string id)
    {
        InventoryList item = HasItem(id);

        if (item != null)
        {
            items.Remove(item);
        }
    }


    /// <summary>
    /// Add weapon to weapon list inventory.
    /// </summary>
    /// <param name="id">string</param>
    /// <param name="quantity">quantity</param>
    public void AddWeapon(string id, int quantity = 1)
    {
        InventoryList weapon = HasWeapon(id);

        if (weapon != null)
        {
            weapon.quantity += quantity;

            if (weapon.quantity > MAX_QUANTITY)
            {
                weapon.quantity = MAX_QUANTITY;
            }

            if (weapon.quantity <= 0)
            {
                RemoveWeapon(id);
            }
        }
        else
        {
            InventoryList newItem = new InventoryList();
            newItem.id = id;
            newItem.quantity = quantity;

            weapons.Add(newItem);
        }
    }

    /// <summary>
    /// Remove weapon from weapons list.
    /// </summary>
    /// <param name="id"></param>
    public void RemoveWeapon(string id)
    {
        InventoryList weapon = HasWeapon(id);

        if (weapon != null)
        {
            weapons.Remove(weapon);
        }
    }

    /// <summary>
    /// Add armor to weapon list inventory.
    /// </summary>
    /// <param name="id">string</param>
    /// <param name="quantity">quantity</param>
    public void AddArmor(string id, int quantity = 1)
    {
        InventoryList armor = HasArmor(id);

        if (armor != null)
        {
            armor.quantity += quantity;

            if (armor.quantity > MAX_QUANTITY)
            {
                armor.quantity = MAX_QUANTITY;
            }

            if (armor.quantity <= 0)
            {
                RemoveArmor(id);
            }
        }
        else
        {
            InventoryList newItem = new InventoryList();
            newItem.id = id;
            newItem.quantity = quantity;

            armors.Add(newItem);
        }
    }

    /// <summary>
    /// Remove armor from armors inventory list
    /// </summary>
    /// <param name="id">string</param>
    public void RemoveArmor(string id)
    {
        InventoryList armor = HasArmor(id);

        if (armor != null)
        {
            armors.Remove(armor);
        }
    }

    /// <summary>
    /// Check if inventory has item.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>InventoryList</returns>
    public InventoryList HasItem(string id)
    {
        return items.Find(i => i.id == id);
    }

    /// <summary>
    /// Check if inventory has weapon.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>InventoryList</returns>
    public InventoryList HasWeapon(string id)
    {
        return weapons.Find(i => i.id == id);
    }

    /// <summary>
    /// Checks if inventory has armor.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>InventoryList</returns>
    public InventoryList HasArmor(string id)
    {
        return armors.Find(i => i.id == id);
    }

    /// <summary>
    /// Get item from items reference if
    /// in inventary.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>Consumable</returns>
    public Consumable GetItem(string id)
    {
        if (HasItem(id) != null)
        {
            return Array.Find(itemsReference, item => item.data.id == id);
        }

        return null;
    }

    /// <summary>
    /// Get weapon from weapon reference.
    /// </summary>
    /// <param name="id">string</param>
    /// <returns>Weapon</returns>
    public Weapon GetWeapon(string id)
    {
        if (HasWeapon(id) != null)
        {
            return Array.Find(weaponReference, weapon => weapon.data.id == id);
        }

        return null;
    }

    /// <summary>
    /// Get armor from armor reference.
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>Armor</returns>
    public Armor GetArmor(string id)
    {
        if (HasArmor(id) != null)
        {
            return Array.Find(armorReference, armor => armor.data.id == id);
        }

        return null;
    }
}
