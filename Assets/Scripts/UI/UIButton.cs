using System;
using UnityEngine;
using System.Collections.Generic;

public class UIButton : MonoBehaviour
{
	private static List<UIButton> buttons = new List<UIButton>();
	
	[SerializeField] private ButtonData buttonData;
	
    public event Action <UIButton, ButtonData> OnHover;
    public event Action <UIButton, ButtonData> OnClick;
    public event Action <UIButton, ButtonData> OnHoverExit;
    
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
		OnHoverExit?.Invoke(this, buttonData);
	}
	private void Click()
	{
		OnClick?.Invoke(this, buttonData);
	}
	
	public static IEnumerable<UIButton> GetUIButtons()
	{
		foreach (UIButton item in buttons)
		{
			yield return item;
		}
	}
}
