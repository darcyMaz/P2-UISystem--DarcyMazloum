using UnityEngine;

public class ButtonManager : MonoBehaviour
{
	// Generalize StartMenuManager into ButtonManager
	// Think over collecting all buttons in this way
	
	private void Awake()
	{
		// Grab all the buttons in the scene
		// Subscribe to their events
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
	
	private void SetButtonStandard(UIButton button, ButtonData buttonData)
	{
		
	}
	
	private void SetButtonHover(UIButton button, ButtonData buttonData)
	{
		
	}
	
	private void SetButtonClick(UIButton button, ButtonData buttonData)
	{
		
	}
	
}
