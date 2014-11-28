#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(150, 280, 400, 130), "Stage01"))
	{
		Application.LoadLevel("Stage01");
        
	}
}