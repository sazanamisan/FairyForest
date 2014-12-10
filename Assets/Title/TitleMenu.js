#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(150, 380, 200, 130), "Start"))
	{
		Application.LoadLevel("FairyForest");
        
	}
	if (GUI.Button(Rect(450, 380, 200, 130), "Game End")) {
	Application.Quit();
	}
}