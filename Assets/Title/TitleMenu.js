#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(350, 280, 400, 130), "Start"))
	{
		Application.LoadLevel("Gestures");
        
	}
}