using UnityEngine;

public class ButtonManager : MonoBehaviour
{
	/**
	 *  The ButtonManager is subscribed to the events on all the buttons.
	 *  It will do stuff related to the buttons that does not directly manipulate those buttons.
	 *  Ex. Audio, scene changes.
	 * 
	 *  Meanwhile, the buttons have their own functions that manipulate themselves.
	 *  Ex. Change the sprite. 
	 **/
	
	// private Dictionary<ButtonType, Func<void,void>> 
	
	private void Awake()
	{
		
	}
	
	private void OnEnable()
	{
		foreach (UIButton button in UIButton.GetUIButtons())
		{
			// subscribe to button events
			button.OnHoverExit += SetButtonStandard;
			button.OnHover += SetButtonHover;
			button.OnClick += SetButtonClick;
		}
	}
	
	private void OnDisable()
	{
		foreach (UIButton button in UIButton.GetUIButtons())
		{
			// unsubscribe to button events
			button.OnHoverExit -= SetButtonStandard;
			button.OnHover -= SetButtonHover;
			button.OnClick -= SetButtonClick;
		}
	}
	
	private void SetButtonStandard(ButtonData buttonData)
	{
		// Using the ButtonData, do stuff that does not directly effect the button.
		// ex. play a sound.
		
		
	}
	
	private void SetButtonHover(ButtonData buttonData)
	{
		
	}
	
	private void SetButtonClick(ButtonData buttonData)
	{
		
	}
}
