using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    private Slider slider;
    private bool FoundSlider = false;
    
    private void Awake()
    {
		if (!TryGetComponent(out slider)) Debug.Log("A SliderUI script could not find its Slider component.");
		FoundSlider = true;
	}
    
    public void UpdateSlider(int val)
    {
		if (FoundSlider)
		{
			slider.value = val;
		}
	}
}
