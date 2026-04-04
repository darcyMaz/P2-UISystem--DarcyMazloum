using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
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
