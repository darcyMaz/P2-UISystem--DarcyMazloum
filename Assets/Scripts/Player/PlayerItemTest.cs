using UnityEngine;

public class PlayerItemTest : MonoBehaviour
{
    public void AddRandomItem()
    {
        System.Random rand = new System.Random();
        int randInt = rand.Next(0,3);

        Debug.Log("rand: " + randInt + " result of conversion: " + (ItemType) randInt);

        PlayerInventory.Instance.AddItem( (ItemType) randInt );
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
