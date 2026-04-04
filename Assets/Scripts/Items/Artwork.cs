using UnityEngine;

[CreateAssetMenu(fileName = "Artwork", menuName = "Scriptable Objects/Artwork")]
public class Artwork : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string keyName = "Artwork";
    [SerializeField] private ItemType itemType = ItemType.Artwork;
    public Sprite GetSprite() => sprite;
    public string GetKeyName() => keyName;
    public ItemType GetItemType() => itemType;
}
