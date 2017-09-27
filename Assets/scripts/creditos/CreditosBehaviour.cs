using UnityEngine;
using System.Collections;

public class CreditosBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0; i<Input.touches.Length; i++){
			Touch touch = Input.touches[i];
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			RaycastHit hit = new RaycastHit();

			if(Physics.Raycast(ray, out hit, 100f)){
				if(hit.collider.name == "back"){
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