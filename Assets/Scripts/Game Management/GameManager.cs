using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

/**
 *  Event choice explanation:
 *  I chose UnityEvents for all but the Timer which uses a C# event.
 * 
 *  The onTimerIncrement event happens many times per second and is thus better suited as a C# event which has better performance.
 *  Meanwhile, the rest of the events are triggered by interacting with other UI elements (and potentially character's interacting with GameObjects),
 *  which are easily configured using UnityEvents.
 *  
 */

public class GameManager : MonoBehaviour
{
	public static GameManager instance {get; private set;}
	
	[SerializeField] UnityEvent onDeath;
    [SerializeField] UnityEvent <int> onHealthChanged;
    [SerializeField] private int StartingHealth;
    [SerializeField] private int MaxHealth;
    private int currentHealth = 0;
    
    [SerializeField] UnityEvent <int> onResourceChanged;
    [SerializeField] private int MaxResource;
    private int currentResource;

    [SerializeField] UnityEvent <int> onScoreChanged;
    [SerializeField] private int MaxScore;
    private int currentScore;
    
    public event Action <float> onTimerIncrement;
    private float timer = 0f;
    
    [SerializeField] private GameObject QuestPanel;
	[SerializeField] private GameObject InventoryPanel;
    
	private List<Button> inventoryButtons = new List<Button>();

    private void Awake()
    {
		if (instance != this && instance != null)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
		
		currentHealth = StartingHealth;
		currentResource = 0;
	}
    
    private void Start()
    {
		// Get all the UI slots in the inventory and add them to the list.
		foreach (Transform child in InventoryPanel.transform)
		{
			Button currentButton;
			if (!child.gameObject.TryGetComponent(out currentButton)) Debug.Log("The GameManager had a problem getting a Button from the inventory UI panel.");
			else
			{
				inventoryButtons.Add(currentButton);
			}
		}

		AdjustInventoryUI();

		onHealthChanged?.Invoke(currentHealth);
		onResourceChanged?.Invoke(currentResource);
	}
	
	private void Update()
	{
		timer += Time.deltaTime;
		onTimerIncrement?.Invoke(timer);
	}
    
    public void ChangeHealth(int diff)
    {
		currentHealth = (currentHealth + diff > MaxHealth) ? MaxHealth : (currentHealth + diff < 0) ? 0: currentHealth + diff;
		onHealthChanged?.Invoke(currentHealth);
		
		if (currentHealth <= 0)
		{
			onDeath?.Invoke();
		}
	}
	
	public void ChangeResource(int diff)
	{
		currentResource = (currentResource + diff > MaxResource) ? MaxResource : (currentResource + diff < 0) ? 0: currentResource + diff;
		onResourceChanged?.Invoke(currentResource);
	}
	
	public void ChangeScore(int diff)
	{
		currentScore = (currentScore + diff > MaxScore) ? MaxScore : (currentScore + diff < 0) ? 0: currentScore + diff;
		onScoreChanged?.Invoke(currentScore);
	}
	
	public void FlipQuestPanel()
	{
		if (QuestPanel != null) 
		{
			QuestPanel.SetActive(!QuestPanel.activeSelf);
		}
	}
	
	public void FlipInventoryPanel()
	{
        if (InventoryPanel != null)
        {
            InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        }
    }

	public void AdjustInventoryUI()
	{
		// Get the count of inventory items
		// Turn on that many buttons, along the way add inventory items' sprites to them

		int itemsTotal = PlayerInventory.Instance.Count();
		int buttonIndex = 0;

		for (; buttonIndex < itemsTotal; buttonIndex++)
		{
			// set button to true and put in the sprite as the image
			inventoryButtons[buttonIndex].gameObject.SetActive(true);

			Image buttonImage;
			if (!inventoryButtons[buttonIndex].gameObject.TryGetComponent(out buttonImage)) Debug.Log("GameManager tried to change the sprite of an item slot in inventory but failed. In AdjustInventoryUI().");
			else
			{
                buttonImage.sprite = PlayerInventory.Instance.GetItemAt(buttonIndex).GetSprite();
			}
		}
		for (; buttonIndex < inventoryButtons.Count; buttonIndex++ )
		{
            // set the button is active to false
            inventoryButtons[buttonIndex].gameObject.SetActive(false);
        }
	}
}
