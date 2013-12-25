using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public Texture2D  btnZoom;
	private float lens = 0.0f;	
	float alpha = 0.0f;
	float f = 50.0f;
	private DepthOfFieldScatter dof = null;
	
	void Start() {
		
		dof = gameObject.GetComponent<DepthOfFieldScatter>();
		
		// Get current camera angle
		alpha = camera.fieldOfView * Mathf.PI / 180 / 2;
		lens = Mathf.Tan(alpha) * 2 * f;		
		
	}
		
	void OnGUI() {
	
		alpha = camera.fieldOfView * Mathf.PI / 180 / 2;
		GUI.DrawTexture(new Rect(0, 0, 64, 64), btnZoom);
		GUI.Label(new Rect(70, 0, 300, 25), "Lens: " + Mathf.Tan(alpha) * 2 * f + " mm");
						
		// Use slider to zoom
		lens = GUI.HorizontalSlider(new Rect(70, 30, 250, 30), lens, 4, 100);
		camera.fieldOfView = 2 * Mathf.Atan(lens / f / 2) * 180 / Mathf.PI;
	
	}
}
