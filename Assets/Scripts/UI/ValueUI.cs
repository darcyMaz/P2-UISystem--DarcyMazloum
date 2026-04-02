using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValueUI : MonoBehaviour
{   
    private TextMeshProUGUI resourceText;
    private bool FoundText = false;
    
    // Ex. Input=23; Leading zeros = 4; => value = 0023 
    [SerializeField] private int LeadingZeros;
    
    private void Awake()
    {
		if (!TryGetComponent(out resourceText))
		{
			Debug.Log("A TextUI could not find its TextMeshProUGUI component.");
		}
		else FoundText = true;
	}
	
	public void ChangeValue(int val)
	{
		if (FoundText) 
		{
			string toSet = val.ToString();
			
			int zerosToAdd = LeadingZeros-toSet.Length;
			
			// Three examples (LeadingZeros = 4 in all examples):
			// val=12000, higher than max of 4 leading zeros, round down to 9999 (i.e. (10*4)-1).
			// val=1200, don't add any leading zeros.
			// val=2, zerosToAdd = 4-1 = 3. So, add three leading zeros => 0002.
			
			if (zerosToAdd < 0) toSet = ((10 * LeadingZeros) - 1).ToString();
			else
			{
				for (int i=0; i<zerosToAdd; i++) toSet = "0" + toSet;
			}
			
			resourceText.text = toSet;
		}
	}
}
