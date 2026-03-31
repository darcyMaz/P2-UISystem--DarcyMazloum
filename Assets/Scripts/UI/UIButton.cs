using System;
using UnityEngine;
using System.Collections.Generic;

public class UIButton : MonoBehaviour
{
	// Do I want this list in UIButton or in StartMenuButton ...
	private static List<UIButton> buttons = new List<UIButton>();
	
	[SerializeField] private ButtonData buttonData;
	
    public event Action <UIButton, ButtonData> OnHover;
    public event Action <ButtonData> OnClick;
    public event Action <ButtonData> OnHoverExit;
    
    private void Awake()
    {
		buttons.Add(this);
	}
    
    private void HoverEnter()
	{
		OnHover?.Invoke(this, buttonData);
	}
	private void HoverExit()
	{
		OnHoverExit?.Invoke(buttonData);
	}
	private void Click()
	{
		OnClick?.Invoke(buttonData);
	}
	
	public static IEnumerable<UIButton> GetUIButtons()
	{
		foreach (UIButton item in buttons)
		{
			yield return item;
		}
	}
}
