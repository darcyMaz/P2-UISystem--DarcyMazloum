using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static Dictionary<ItemType, Item> items = new Dictionary<ItemType, Item>();

    /*
    static ItemManager()
    {
        //items.Add(ItemType.Key, ScriptableObject.CreateInstance<Key>());
        //items.Add(ItemType.Tool, ScriptableObject.CreateInstance<Tool>());
        //items.Add(ItemType.Artwork, ScriptableObject.CreateInstance<Artwork>());

        Debug.Log("static constructor");

        Artwork[] artworks = Resources.LoadAll<Artwork>("Assets/ScriptableObjects/Items/Artworks");

        Debug.Log(artworks.Length);

        foreach (Artwork art in artworks)
        {
            Debug.Log(art.GetItemName());
        }
    }
    */

    private void Awake()
    {
        Artwork[] artworks = Resources.LoadAll<Artwork>("ScriptableObjects/Items/Artworks");

        Debug.Log(artworks.Length);

        foreach (Artwork art in artworks)
        {
            Debug.Log(art.GetItemName());
        }
    }

    public static Item GetItem(ItemType type)
    {
        return items[type];
    }
}
