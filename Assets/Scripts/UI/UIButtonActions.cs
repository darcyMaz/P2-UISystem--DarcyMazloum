using UnityEngine;

public class UIButtonActions : MonoBehaviour
{
    // Listens to UIButton and does nothing on hover, on vlick, on hover exit
    // Classes extend from this have specific functionality
    
    private UIButton button;
    private bool FoundButton = false;
    
    private void Awake()
    {
		// get button
		// subscribe to functions
		
		if (!TryGetComponent(out button)) Debug.Log("A UIButtonActions component could not find a UIButton on the same GameObject.");
		else FoundButton = true;
	}
	
	private void OnEnable()
	{
		button.OnHover += onHover;
		button.OnHoverExit += onHoverExit;
		button.OnClick += onClick;
	}
	
	// Then this will be overwritten by UIBA_Start, UIBA_Settings, etc.
	protected virtual void onClick(ButtonData bd)
	{
		if (FoundButton)
		{
			// this parent class does nothing
			// extend another class from it to implement the actions.
		}
	}
	protected virtual void onHover(ButtonData bd)
	{
		if (FoundButton)
		{
			// this parent class does nothing
			// extend another class from it to implement the actions.
		}
	}
	protected virtual void onHoverExit(ButtonData bd)
	{
		if (FoundButton)
		{
			// this parent class does nothing
			// extend another class from it to implement the actions.
		}
	}
	
}
