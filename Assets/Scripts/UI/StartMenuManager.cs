using UnityEngine;
using UnityEngine.UI;

/**
 *  Render mode decision: I chose Screen Space - Overlay because the main menu does not rely on anything in front of the camera like moving GameObjects or lighting effects. 
 *  I also don't need to worry about z-positioning as the menu is very simple.
 * 
 * */

public class StartMenuManager : MonoBehaviour
{
	[SerializeField] private Button StartButton;
	[SerializeField] private Button SettingsButton;
	[SerializeField] private Button CloseSettingsButton;
	[SerializeField] private Button QuitButton;
	
	[SerializeField] private GameObject panel;
	
	[SerializeField] private string StartSceneName;
	
	private void OnEnable()
	{
		StartButton.onClick.AddListener(StartGame);
		QuitButton.onClick.AddListener(QuitGame);
		SettingsButton.onClick.AddListener(OpenSettings);
		CloseSettingsButton.onClick.AddListener(CloseSettings);
	}
	private void OnDisable()
	{
		StartButton.onClick.RemoveListener(StartGame);
		QuitButton.onClick.RemoveListener(QuitGame);
		SettingsButton.onClick.RemoveListener(OpenSettings);
		CloseSettingsButton.onClick.RemoveListener(CloseSettings);
	}
	
	private void StartGame()
	{
		SceneManager.Instance.BufferSceneChange(StartSceneName);
	}
	private void QuitGame()
	{
		Application.Quit();
	}
	private void OpenSettings()
	{
		panel.SetActive(true);
	}
	private void CloseSettings()
	{
		panel.SetActive(false);
	}
}
