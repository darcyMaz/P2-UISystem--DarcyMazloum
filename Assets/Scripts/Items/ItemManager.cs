using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static Dictionary<ItemType, Item> items = new Dictionary<ItemType, Item>();

    private void Awake()
    {
        items.Add(ItemType.Key,ScriptableObject.CreateInstance<Key>());
        items.Add(ItemType.Tool, ScriptableObject.CreateInstance<Tool>());
        items.Add(ItemType.Artwork, ScriptableObject.CreateInstance<Artwork>());
    }

    public static Item GetItem(ItemType type)
    {
        return items[type];
    }
}
