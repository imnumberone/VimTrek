using UnityEngine;
using System.Collections;

public class CameraCapture : MonoBehaviour {
	
	public Texture2D btnCapture;
	private Texture2D tex;
	
	private IEnumerator TakeScreenshot()
	{
		yield return new WaitForEndOfFrame();
		
		int width = Screen.width;
		int height = Screen.height;
		tex = new Texture2D(width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();
	}
	
	void OnGUI() {
	
		if(GUI.Button(new Rect(Screen.width - 128, Screen.height/2 - 128, 128, 128), btnCapture)) {
			StartCoroutine("TakeScreenshot");
						
		}
		if(tex != null) {
			GUI.DrawTexture(new Rect(0, Screen.height - Screen.height/4, Screen.width/4, Screen.height/4), tex);
		}
		
	}
}
