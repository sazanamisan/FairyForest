#pragma strict

function OnGUI()
{
	if (GUI.Button(Rect(150, 280, 100, 30), "Retry"))
	{
		Application.LoadLevel("Stage01");
	}
}