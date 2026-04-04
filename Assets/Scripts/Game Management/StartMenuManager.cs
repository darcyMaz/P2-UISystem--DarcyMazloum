using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

/**
 *  Render mode decision: I chose Screen Space - Overlay because the main menu does not rely on anything in front of the camera like moving GameObjects or lighting effects. 
 *  I also don't need to worry about z-positioning as the menu is very simple.
 * 
 * */

public class StartMenuManager : MonoBehaviour
{
	[SerializeField] UnityEvent OnReady;
	[SerializeField] UnityEvent OnStart;
	[SerializeField] UnityEvent OnSettings;
	[SerializeField] UnityEvent OnQuit;

	private StartMenuState state = StartMenuState.Ready;
	public StartMenuState GetStartMenuState() => state;
	
	[SerializeField] private GameObject panel;
	[SerializeField] private string StartSceneName;

	public void StartGame()
	{
		state = StartMenuState.Start;
		OnStart?.Invoke();
        SceneManager.Instance.BufferSceneChange(StartSceneName);
    }
	public void QuitGame()
	{
		state = StartMenuState.Quit;
		OnQuit?.Invoke();
        Application.Quit();
    }
    public void OpenSettings()
    {
		state = StartMenuState.Settings;
		OnSettings?.Invoke();
        panel.SetActive(true);
    }
    public void CloseSettings()
    {
		state = StartMenuState.Ready;
		OnReady?.Invoke();
        panel.SetActive(false);
    }
}

public enum StartMenuState
{
	Ready,
	Start,
	Settings,
	Quit
}
