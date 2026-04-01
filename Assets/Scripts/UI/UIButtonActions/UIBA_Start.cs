using UnityEngine;

public class UIBA_Start : UIButtonActions
{
    protected override void onClick(ButtonData bd)
    {
		Debug.Log(bd.GetButtonType() + " click");
	}
	protected override void onHover(ButtonData bd)
    {
		Debug.Log(bd.GetButtonType() + " hover");
	}
	protected override void onHoverExit(ButtonData bd)
    {
		Debug.Log(bd.GetButtonType() + " hover exit");
	}
}
