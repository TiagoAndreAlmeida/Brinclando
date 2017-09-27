using UnityEngine;
using System.Collections;

public class menuBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)) {}

		for(int i = 0; i<Input.touches.Length; i++){

			Touch touch = Input.touches[i];
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit = new RaycastHit();

			if(Physics.Raycast(ray, out hit, 100f)){

				if(hit.collider.name == "start"){
					switch (touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(1);
						break;
					}
				}
				if(hit.collider.name == "credits"){
					switch (touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(4);
						break;
					}
				}
				if(hit.collider.name == "quit"){		
					switch (touch.phase){
						case TouchPhase.Began:
							Application.Quit();
						break;
					}
				}
			}
		}

	}
}
