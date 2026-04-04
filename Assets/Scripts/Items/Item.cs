using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public abstract class Item : ScriptableObject
{
    public abstract Sprite GetSprite();
    public abstract string GetItemName();
    public abstract ItemType GetItemType();
}
