using UnityEngine;
using System;
using TMPro;

public class TimerUI : MonoBehaviour
{
	private TextMeshProUGUI timerText;
	private bool FoundText = false;
	
	private void Awake()
	{
		if (!TryGetComponent(out timerText)) Debug.Log("A TimerUI could not find its TextMeshProUGUi component.");
		else FoundText = true;
	}
	
    private void OnEnable()
    {
		if (FoundText) GameManager.instance.onTimerIncrement += UpdateTimer;
	}
	private void OnDisable()
    {
		if (FoundText) GameManager.instance.onTimerIncrement += UpdateTimer;
	}
	
	private void UpdateTimer(float newTime)
	{
		TimeSpan time = TimeSpan.FromSeconds(newTime);
		timerText.text = time.ToString("hh':'mm':'ss");
	}
}
