using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	/**
	 *  The UIButton class is a generalized class for using buttons.
	 *  Each button has three events.
	 *  
	 *  The UIButton class only responds to those events with functionality that directly effects the button.
	 *  Ex. Change the sprite.
	 *  Counter Ex. Change the scene, play a sound, do 3d effects.
	 * 
	 */
	
	private static List<UIButton> buttons = new List<UIButton>();
	
	[SerializeField] private ButtonData buttonData;
	
    public event Action <ButtonData> OnHover;
    public event Action <ButtonData> OnClick;
    public event Action <ButtonData> OnHoverExit;
    
    private Button button;
    private bool FoundButton = false;
    
    private Image img;
    private bool FoundImg = false;
    
    private bool SpriteLock = false;
    
    private void Awake()
    {
		// Add this button to the list of buttons.
		buttons.Add(this);
		
		if (!TryGetComponent(out button)) Debug.Log("A UIButton Component could not find the Button it is supposed to be attached to.");
		else FoundButton = true;
		
		if (!TryGetComponent(out img)) Debug.Log("A UIButton Component could not find the Image component.");
		else FoundImg = true;
		
		if (FoundButton)
		{
			button.onClick.AddListener(Click);
		}
	}
    
    private void HoverEnter()
	{
		if (!FoundButton) return;
		
		// Invoke the events for other objects.
		OnHover?.Invoke(buttonData);
		
		// Manipulate this button directly.
	}
	
	private void HoverExit()
	{
		if (!FoundButton) return;
		OnHoverExit?.Invoke(buttonData);
	}
	
	private void Click()
	{
		if (!FoundButton) return;
		
		if (FoundImg) 
		{
			SpriteLock = true;
			img.sprite = buttonData.GetClickSprite();
			//SpriteLock = true;
		}
		
		OnClick?.Invoke(buttonData);
	}
	
	public void OnPointerEnter(PointerEventData eventData)
    {
		if (FoundImg && !SpriteLock) img.sprite = buttonData.GetHoverSprite();
		HoverEnter();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (FoundImg && !SpriteLock) img.sprite = buttonData.GetStandardSprite();
        HoverExit();
    }
    
    public static IEnumerable<UIButton> GetUIButtons()
	{
		foreach (UIButton item in buttons)
		{
			yield return item;
		}
	}
}
