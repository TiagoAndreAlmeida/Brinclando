using UnityEngine;
using System.Collections;

public class trashBehaviour : MonoBehaviour {

	private GameController gameController;
	private Animator animTrash;

	// Use this for initialization
	void Awake () {

		gameController = GameObject.Find("Main Camera").GetComponent<GameController> ();
		animTrash = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if( gameController.GetStateMachine() == stateMachine.PLAY ){
			animTrash.speed = 1f;
		}else if( gameController.GetStateMachine() == stateMachine.LOSE ){
			animTrash.speed = 0f;
		}
	
	}
}