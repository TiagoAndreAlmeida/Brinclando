using UnityEngine;
using System.Collections;

public class tutorialBehaviour : MonoBehaviour {

	public Animator cameraAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < Input.touches.Length; i++){

			Touch touch = Input.touches[i];
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, 100f)){

				if(hit.collider.name == "next"){

					switch(touch.phase){
						case TouchPhase.Began:
								cameraAnim.SetBool ("next", true);
						break;
					}
				}

				if(hit.collider.name == "next1"){
					
					switch(touch.phase){
						case TouchPhase.Began:
							cameraAnim.SetBool("next1",true);
						break;
					}
				}

				if(hit.collider.name == "start"){

					switch(touch.phase){
						case TouchPhase.Began:
							Application.LoadLevel(2);
						break;
					}
				}
			}
		}
	
	}
}
