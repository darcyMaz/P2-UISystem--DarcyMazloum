using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Scriptable Objects/Tool")]
public class Tool : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string keyName = "Tool";
    [SerializeField] private ItemType itemType = ItemType.Tool;

    public Sprite GetSprite() => sprite;
    public string GetKeyName() => keyName;
    public ItemType GetItemType() => itemType;
}
