using UnityEngine;

[CreateAssetMenu(fileName = "ButtonData", menuName = "Scriptable Objects/ButtonData")]
public class ButtonData : ScriptableObject
{
    [SerializeField] private Sprite standardSprite;
    [SerializeField] private Sprite hoverSprite;
    [SerializeField] private Sprite clickSprite;
    [SerializeField] private ButtonType buttonType;
    
    // could add sound bite here
    // could add other things as well I suppose idk what tho
    
    public Sprite GetStandardSprite() => standardSprite;
    public Sprite GetHoverSprite() => hoverSprite;
    public Sprite GetClickSprite() => clickSprite;
    public ButtonType GetButtonType() => buttonType;
    
}
