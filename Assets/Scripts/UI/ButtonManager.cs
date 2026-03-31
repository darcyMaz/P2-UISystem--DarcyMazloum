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
		
	}
	
	private void SetButtonHover(ButtonData buttonData)
	{
		
	}
	
	private void SetButtonClick(ButtonData buttonData)
	{
		
	}
	
}
