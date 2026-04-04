using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects/Key")]
public class Key : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string keyName = "Key";
    [SerializeField] private int doorThisKeyOpens = 0; // Imagine that this field is more developed in some way for a real game.
    [SerializeField] private ItemType itemType = ItemType.Key;

    public Sprite GetSprite() => sprite;
    public string GetKeyName() => keyName;
    public int GetDoorThisKeyOpens() => doorThisKeyOpens;
    public ItemType GetItemType() => itemType;
}
