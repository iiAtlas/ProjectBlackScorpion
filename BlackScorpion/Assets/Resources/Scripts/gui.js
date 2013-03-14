var crosshairTexture : Texture2D;
private var position : Rect;
static var OriginalOn = true;
 
function Start()
{
    position = Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - 
        crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
}
 
function Update() {
	if(Input.GetKeyDown(KeyCode.Backslash)) Application.LoadLevel(Application.loadedLevel);
	Screen.lockCursor = true;
}
 
function OnGUI()
{
    if(OriginalOn == true) {
        GUI.DrawTexture(position, crosshairTexture);
    }
}