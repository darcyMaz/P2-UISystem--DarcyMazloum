Darcy Mazloum
2545876

Context:
The Start Menu has buttons which I cut up and scaned myself. Not sure what the context is, I just felt like doing that!
The Game Scene has all the UI elements mentioned in the assignment, but the Quest Log and the Inventory Items implies it is a heist game! Keys, tools, and art works.

Item System:
It's got a collectible inventory system. You can add random items, remove random items, or remove specific items from the inventory by pressing them.

Event Approach:
I used the UnityEvents approach with the exception of an event for the timer which used C# events.
I used UnityEvents for two reasons:
(1) the events are infrequent (pressing a button, picking up one item at a time, etc.) thus performance, which would be better with C# events, are irrelevent and 
(2) these events are related to the UI, which are generally better suited for UnityEvents because Unity offers ways to connect them without code.

The timer event happens every frame as the time is incremented every frame. The frequency of this event leads me to prefer a C# event which is better for performance.

Everything is implemented, there are no limitations to mention.
