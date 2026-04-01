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
	
	public void RegisterButton(int buttonID, Action action)
	{
		// Try add, I'll check this
		actions.Add(buttonID, action);
	}
	public void DeregisterButton(int buttonID)
	{
		// Try remove button from dict
		actions.Remove(buttonID);
	}
	
	/*
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
	*/
	
	
	
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
