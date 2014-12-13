#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(250, 280, 200, 100), "Retry"))
	{
		Application.LoadLevel("Stage01");
	}
    if (GUI.Button(Rect(450, 280, 200, 100), "StageSelect"))
	{
		Application.LoadLevel("StageSelect");
	}
    if (GUI.Button(Rect(650, 280, 200, 100), "NextStage"))
	{
		Application.LoadLevel("Stage01");
	}
}