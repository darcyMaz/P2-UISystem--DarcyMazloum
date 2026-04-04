using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // I feel as though this isn't the best way to do this, but looking for a specific item is in O(n)... if you know what ItemType it is at least.

    private static Dictionary<ItemType, Item[]> items = new Dictionary<ItemType, Item[]>();

    private void Awake()
    {
        Item[] artworks = Resources.LoadAll<Artwork>("ScriptableObjects/Items/Artworks");
        Item[] keys = Resources.LoadAll<Artwork>("ScriptableObjects/Items/Keys");
        Item[] tools = Resources.LoadAll<Artwork>("ScriptableObjects/Items/Tools");

        items.Add(ItemType.Artwork, artworks);
        items.Add(ItemType.Key, keys);
        items.Add(ItemType.Tool, tools);
    }

    public static Item[] GetItemList(ItemType type)
    {
        return items[type];
    }

    public static Item TryGetItem(ItemType type, string name)
    {
        Item[] itemList; 
        items.TryGetValue(type, out itemList);
        if (itemList == null) { Debug.Log("An attempt to get an item from the item list failed. The ItemType was invalid.");  return null; }

        foreach (Item i in itemList)
        {
            if (i.GetItemName() == name)
            {
                return i;
            }
        }

        Debug.Log("An attempt to get an item from the item list failed. The string was invalid.");
        return null;
    }
}
