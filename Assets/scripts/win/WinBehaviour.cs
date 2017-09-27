using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinBehaviour : MonoBehaviour {

	public Text time;

	// Use this for initialization
	void Start () {
		time.text = "Seu tempo: " + PlayerPrefs.GetFloat ("time");
	}
	
	// Update is called once per frame
	void Update () {

		//if(Input.GetKeyDown(KeyCode.Escape)) {}

		for(int i = 0; i<Input.touches.Length; i++){
			
			Touch touch = Input.touches[i];
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit = new RaycastHit();
			
			if(Physics.Raycast(ray, out hit, 100f)){
				if(hit.collider.name == "start"){
					switch(touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(1);
						break;
					}
				}
				if(hit.collider.name == "exit"){
					switch(touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(0);
						break;
				}
			}
		}

	}
}
}
