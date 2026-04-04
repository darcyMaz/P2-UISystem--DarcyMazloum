using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Scriptable Objects/Key")]
public class Key : Item
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string keyName = "Key";
    [SerializeField] private ItemType itemType = ItemType.Key;

    public override Sprite GetSprite() => sprite;
    public override string GetItemName() => keyName;
    public override ItemType GetItemType() => itemType;
}
