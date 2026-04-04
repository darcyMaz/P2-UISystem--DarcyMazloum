using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // this class has an on inventory changed event
    // game manager listens to this, and calls an update inventory ui function which
    //      takes the inventory list and reorders it into the ui
    //      GM gets the count of the inventory list, turns on that many ui elements, and then sequentially changes the sprites of those items

    // what about using items? each button has a function UseItem() which tells the GM its position in the UI and invokes an event that the player inventory listens to which removes items from the PlayerInventory list
}
