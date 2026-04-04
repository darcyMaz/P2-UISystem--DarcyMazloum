using UnityEngine;

[CreateAssetMenu(fileName = "Artwork", menuName = "Scriptable Objects/Artwork")]
public class Artwork : Item
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string artworkName = "Artwork";
    private ItemType itemType = ItemType.Artwork;
    public override Sprite GetSprite() => sprite;
    public override string GetItemName() => artworkName;
    public override ItemType GetItemType() => itemType;
}
