using UnityEngine;
using System.Collections;

public class CamDOF : MonoBehaviour {
	
	private float fStop = 2.0f;		
	private DepthOfFieldScatter dof = null;
	public Texture2D btnAperture;
	
	void Start() {
	
		dof = gameObject.GetComponent<DepthOfFieldScatter>();
		
	}
	
	void Update() {
	
		if(Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit)) {
				dof.focalLength = hit.distance;
				fStop = Mathf.Clamp(dof.focalLength/dof.aperture, 1.0f, 22.0f);
			}
		}	
	}
	
	
	void OnGUI() {
		
		// Aperture
		GUI.Label(new Rect(70, 140, 300, 25), "F-stop: " + fStop);
		GUI.DrawTexture(new Rect(0, 140, 64, 64), btnAperture);
		fStop = GUI.HorizontalSlider(new Rect(70, 170, 250, 30), fStop, 1, 22);
		dof.aperture = dof.focalLength / fStop;  
		
	}
}