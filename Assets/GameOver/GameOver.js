#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(250, 380, 200, 100), "Retry"))
	{
		Application.LoadLevel("FairyForest");
	}
    if (GUI.Button(Rect(650, 380, 200, 100), "Go To Title"))
	{
		Application.LoadLevel("Title");
	}
    
}