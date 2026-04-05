using UnityEngine;
using UnityEngine.Events;

/**
 *  Render mode decision: I chose Screen Space - Overlay because the Canvas on both the Start Menu and the Game Scene rely neither on the camera or the position in the world.
 *						  The Canvas should be on the screen at all times.
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
