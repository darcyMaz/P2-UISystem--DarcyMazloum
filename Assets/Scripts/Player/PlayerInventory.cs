using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    // This is a singleton so I can make it an instance.
    // Well actually, there could be many players in the game. Splitscreen.
    // I'm going to make it a singleton because this design pattern is compatible with a change that adds players.
    // Ok wait it doesn't need to be an instance of a singleton because unity events are easy thru inspector.

    // this class has an on inventory changed event
    // game manager listens to this, and calls an update inventory ui function which
    //      takes the inventory list and reorders it into the ui
    //      GM gets the count of the inventory list, turns on that many ui elements, and then sequentially changes the sprites of those items

    // what about using items? each button has a function UseItem() which tells the GM its position in the UI
    //      and invokes an event that the player inventory listens to which removes items from the PlayerInventory list

    public static PlayerInventory Instance { get; private set; }

    [SerializeField] UnityEvent onInventoryChanged;
    [SerializeField] UnityEvent <string> onItemAddFailed;
    [SerializeField] UnityEvent <string> onItemRemoveFailed;
    private List<Item> inventory = new List<Item>();

    [SerializeField] private int MaximumItems = 16;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddItem(Item item)
    {
        if (inventory.Count == MaximumItems)
        {
            onItemAddFailed?.Invoke("Inventory full.");
            return;
        }

        inventory.Add(item);
        onInventoryChanged?.Invoke();
    }

    public void RemoveItem(int index)
    {
        if (index >= inventory.Count)
        {
            onItemRemoveFailed?.Invoke("You tried to remove an item, but there is no item at that spot in the list!");
            return;
        }

        inventory.RemoveAt(index);
        onInventoryChanged?.Invoke();
    }

    public Item GetItemAt(int index)
    {
        return inventory[index];
    }

    public int Count()
    {
        return inventory.Count;
    }

    public int MaxItemCount()
    {
        return MaximumItems;
    }

    public IEnumerable<Item> GetInventory()
    {
        foreach (Item item in inventory)
        {
            yield return item;
        }
    }
}
