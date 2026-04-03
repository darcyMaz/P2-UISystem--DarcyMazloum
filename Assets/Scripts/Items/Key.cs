using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects/Key")]
public class Key : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string keyName;
    [SerializeField] private int doorThisKeyOpens; // Imagine that this field is more developed in some way for a real game.
    [SerializeField] private ItemType itemType;
    
    //protected virtual Sprite GetSprite() => sprite;
    //protected virtual string GetKeyName() => keyName;
    //protected virtual int GetDoorThisKeyOpens() => doorThisKeyOpens;
    //protected ItemType GetItemType() => itemType;
}
