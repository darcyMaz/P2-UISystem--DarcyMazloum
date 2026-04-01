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
	
	private static int ButtonIDCounter = -1;
	private int ButtonID;
	
	// ButtonData holds specific data for this button.
	// It is held in a ScriptableObject.
	[SerializeField] private ButtonData buttonData;
	
    public event Action OnHover;
    public event Action OnClick;
    public event Action OnHoverExit;
    
    // The Button object on the canvas.
    private Button button;
    private bool FoundButton = false;
    
    // The Image object on the canvas, where the sprites go.
    private Image img;
    private bool FoundImg = false;
    
    protected virtual void Awake()
    {	
		ButtonIDCounter++;
		ButtonID = ButtonIDCounter; 
		
		MainMenuManager.Instance.RegisterButton(this, ButtonID, ClickAction);
		
		// Try to find the Button and the Image components.
		if (!TryGetComponent(out button)) Debug.Log("A UIButton Component could not find the Button it is supposed to be attached to.");
		else FoundButton = true;
		
		if (!TryGetComponent(out img)) Debug.Log("A UIButton Component could not find the Image component.");
		else FoundImg = true;
		
		// Add the Click() function to the Button's onClick listeners.
		if (FoundButton)
		{
			button.onClick.AddListener(Click);
		}
	}
	
	protected virtual void ClickAction()
	{
		// This will be overwritten by a child class.
	}
	
	private void OnDisable()
	{
		// Check this.
		// button.onClick.RemoveListener(Click);
	}
	
	private void Click()
	{	
		if (FoundImg) 
		{
			img.sprite = buttonData.GetClickSprite();
		}
		if (FoundButton)
		{
			OnClick?.Invoke();
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData)
    {
		if (FoundImg) 
		{
			img.sprite = buttonData.GetHoverSprite();
		}
		if (FoundButton) 
		{
			OnHover?.Invoke();
		}
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (FoundImg) 
        {
			img.sprite = buttonData.GetStandardSprite();
		}
		if (FoundButton)
		{
			OnHoverExit?.Invoke();
		}
    }
}
