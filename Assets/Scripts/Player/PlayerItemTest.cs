using UnityEngine;

public class PlayerItemTest : MonoBehaviour
{

    public void AddRandomItem()
    {
        System.Random rand = new System.Random();
        int randIntItemType = rand.Next(0,3);

        Debug.Log("rand: " + randIntItemType + " result of conversion: " + (ItemType)randIntItemType);

        ItemType randIT = (ItemType)randIntItemType;
        Item[] itemsToChooseFrom = ItemManager.GetItemList(randIT);
        int randIntIndex = rand.Next(0,itemsToChooseFrom.Length-1);

        PlayerInventory.Instance.AddItem(itemsToChooseFrom[randIntIndex] );

        // Get a random itemtype then get its corresponding item list, and add one of those at random.
    }
    public void RemoveRandomItem() 
    {
        if (PlayerInventory.Instance.Count() == 0)
        {
            Debug.Log("PlayItemTest tried to remove an item but couldn't because the inventory is empty.");
            return;
        }

        System.Random rand = new System.Random();
        int randInt = rand.Next(0, PlayerInventory.Instance.Count() - 1);

        PlayerInventory.Instance.RemoveItem( randInt );
    }
}
