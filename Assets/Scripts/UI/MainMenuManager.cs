using UnityEngine;
using System.Collections.Generic;
using System;

public class MainMenuManager : MonoBehaviour
{
	/**
	 *  The ButtonManager is subscribed to the events on all the buttons.
	 *  It will do stuff related to the buttons that does not directly manipulate those buttons.
	 *  Ex. Audio, scene changes.
	 * 
	 *  Meanwhile, the buttons have their own functions that manipulate themselves.
	 *  Ex. Change the sprite. 
	 **/
	
	public static MainMenuManager Instance {get; private set;}
	private Dictionary<int, Action> actions = new Dictionary<int, Action>();
	
	private void Awake()
	{
		if (Instance != null && Instance != this) {Destroy(gameObject); return;}
		Instance = this;
	}
	
	public void RegisterButton(UIButton button, int buttonID, Action action)
	{
		// Try add, I'll check this
		actions.Add(buttonID, action);
		
		// susbcribe to the button
		button.OnClick += action;
	}
	public void DeregisterButton(UIButton button, int buttonID)
	{
		// Unsubscribe from the button's action.
		button.OnClick -= actions[buttonID];
		
		// Try remove button from dict
		actions.Remove(buttonID);
	}
	
}
