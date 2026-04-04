using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Scriptable Objects/Tool")]
public class Tool : Item
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string itemName = "Tool";
    private ItemType itemType = ItemType.Tool;

    public override Sprite GetSprite() => sprite;
    public override string GetItemName() => itemName;
    public override ItemType GetItemType() => itemType;
}
