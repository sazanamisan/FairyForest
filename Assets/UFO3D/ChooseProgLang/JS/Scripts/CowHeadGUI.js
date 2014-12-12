//This script shows a GUI texture on screen, scaling it up from 1 pixel to 64. Used to show a cow head whenever a cow is put in the portal

function Start()
{
	transform.guiTexture.pixelInset.width = transform.guiTexture.pixelInset.height = 1; //set pixel width and height tp 1
}

function Update () 
{
	if ( transform.guiTexture.pixelInset.width < 64 ) //limit pixel width and height to 64
	{
		transform.guiTexture.pixelInset.width = transform.guiTexture.pixelInset.height += 2; //increase pixel width and height
	}
}