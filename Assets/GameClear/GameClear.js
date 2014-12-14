#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(250, 480, 200, 100), "Retry"))
	{
		Application.LoadLevel("FairyForest");
	}
    if (GUI.Button(Rect(650, 480, 200, 100), "Go To Title"))
	{
		Application.LoadLevel("Title");
	}
    
}