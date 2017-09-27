using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	//public Vector2 limitScreen;
	public float speed_x, speed_z, 
				 timeToRotate, currentTimeToRotate,
				 limitTop, limitDown, limitLeft, limitRigth;

	public GameController gameController;

	private Animator animatorEnemy;

	// Use this for initialization
	void Awake () {

		gameController = GameObject.Find("Main Camera").GetComponent<GameController>();
		animatorEnemy = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if( gameController.GetStateMachine() == stateMachine.PLAY ) {

			currentTimeToRotate += Time.deltaTime;


			if( Physics.Raycast(transform.position, Vector3.right, 0.6f) ){
				//print("rigth");
				//transform.position = new Vector3(limitScreen.x, transform.position.y, 0);
				//transform.eulerAngles = new Vector3(0,0,0);
				transform.eulerAngles = new Vector3(0,-90,0);


				//randomDirectionY ();
			}
			if( Physics.Raycast(transform.position, Vector3.left, 0.6f )) {
				//print("left");
				//transform.position = new Vector3(-limitScreen.x, transform.position.y, 0);
				//transform.eulerAngles = new Vector3(0,0,0);
				transform.eulerAngles = new Vector3(0,90,0);
				//randomDirectionY ();
			}
			if( Physics.Raycast(transform.position, Vector3.forward, 0.6f) ){
				//print("forward");
				//transform.position = new Vector3(transform.position.x, limitScreen.y, 0);
				//randomDirectionX ();
				//transform.eulerAngles = new Vector3(0,0,0);
				transform.eulerAngles = new Vector3(0,180,0);
			}
			if( Physics.Raycast(transform.position, Vector3.back, 0.6f) ){
				//print("back");
				//transform.position = new Vector3(transform.position.x, -limitScreen.y, 0);
				//randomDirectionX ();
				transform.eulerAngles = new Vector3(0,0,0);
			}
			//transform.Translate (speed_x * Time.deltaTime, 0, speed_z * Time.deltaTime);
			transform.Translate (0, 0, speed_z * Time.deltaTime);

			if( currentTimeToRotate > timeToRotate){
				newDirection();
				currentTimeToRotate = 0f;
			}

			if( transform.position.z > limitTop ) transform.position = new Vector3(transform.position.x, 0, limitTop);
			if( transform.position.z < limitDown ) transform.position = new Vector3(transform.position.x, 0, limitDown);
			if( transform.position.x < limitLeft ) transform.position = new Vector3(transform.position.z, 0, limitLeft);
			if( transform.position.x > limitRigth ) transform.position = new Vector3(transform.position.z, 0, limitRigth);

		}else if(gameController.GetStateMachine() == stateMachine.LOSE){
			animatorEnemy.SetBool("isPlayer",false);
		}


	}

	void newDirection(){
		float newRotation = Random.Range(0,361);
		transform.eulerAngles = new Vector3 (0,newRotation,0);
	}
	/*
	void OnTriggerEnter (Collider hit) {

		if(hit.tag == "colisorPlastico"){
			transform.eulerAngles = new Vector3 (0,-145,0);
			currentTimeToRotate = 0;
		}
		if(hit.tag == "colisorVidro"){
			transform.eulerAngles = new Vector3 (0,-45,0);
			currentTimeToRotate = 0;
		}
		if(hit.tag == "colisorMetal"){
			transform.eulerAngles = new Vector3 (0,45,0);
			currentTimeToRotate = 0;
		}
		if(hit.tag == "colisorPapel"){
			transform.eulerAngles = new Vector3 (0,145,0);
			currentTimeToRotate = 0;
		}

		if(hit.gameObject.name == "wallTop"){
			transform.eulerAngles = new Vector3 (0,180,0);
			currentTimeToRotate = 0;
		}
		if(hit.gameObject.name == "wallDown"){
			transform.eulerAngles = new Vector3 (0,0,0);
			currentTimeToRotate = 0;
		}
		if(hit.gameObject.name == "wallRigth"){
			transform.eulerAngles = new Vector3 (0,-90,0);
			currentTimeToRotate = 0;
		}
		if(hit.gameObject.name == "wallLeft"){
			transform.eulerAngles = new Vector3 (0,90,0);
			currentTimeToRotate = 0;
		} 

	} */

	/*
	void randomDirectionX (){

		speed_z *= -1;

		if( Random.Range(-1,1) > -1){
			speed_x = speed_x * 1;
		}else{
			speed_x = speed_x * -1;
		}

	}

	void randomDirectionY (){

		speed_x *= -1;

		if( Random.Range(-1,1) > -1){
			speed_z = speed_z * 1;
		}else{
			speed_z = speed_z * -1;
		}
	} */
}
