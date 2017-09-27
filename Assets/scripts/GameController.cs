using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum stateMachine {

	START,
	PLAY,
	SWITCHCLOTHES,
	LOSE,
	WIN,
	NULL
}

public class GameController : MonoBehaviour {

	private stateMachine currentState = stateMachine.START;
	private stateMachine lastState = stateMachine.NULL;

	private Quaternion staticRotation = new Quaternion(314.9998f, -1.867453e-05f, 180.0003f, 0f);

	//private float smoothTime = 0.3f;
	private float time = 0f;
	public float currentVelocity;

	public PlayerBehaviour player;
	public EnemyBehaviour enemy;

	public GameObject[] lixeiras = new GameObject[4];

	private Vector3 metalPosition;
	private Vector3 plasticoPosition;
	private Vector3 vidroPosition;
	private Vector3 papelPosition;
	//UI variable's
	public Text timeText;
	private float timeGame;

	// Use this for initialization
	void Start () {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

	}
	
	// Update is called once per frame
	void Update () {

		GameStateMachine ();
	
	}

	public void SwitchState( stateMachine nextState ) {

		Debug.Log ("trocou de :" + currentState + " para: " + nextState);
		lastState = currentState;
		currentState = nextState;

	}

	void GameStateMachine () {

		switch(currentState){

			case stateMachine.START :
			{
				papelPosition = new Vector3(-6.452891f, -0.4166487f, 2.260601f);
				plasticoPosition = new Vector3(5.98177f, -0.4166061f, 2.260562f);
				metalPosition = new Vector3(-6.452891f, -0.4166487f, -4.655929f);
				vidroPosition = new Vector3(6.136856f, -0.4166487f, -4.543095f);
				SwitchState(stateMachine.PLAY);
			}
			break;

			case stateMachine.PLAY :
			{
				player.MovePlayer();
				//FollowPlayer ();
				if(lastState == stateMachine.SWITCHCLOTHES){
					
					if(player.lastTrash == "metal"){
						SpawnTrash(lixeiras[0], metalPosition, staticRotation);
						player.lastTrash = "";
					}
					if(player.lastTrash == "plastico"){
						SpawnTrash(lixeiras[1], plasticoPosition, staticRotation);
						player.lastTrash = "";
					}
					if(player.lastTrash == "vidro"){
						SpawnTrash(lixeiras[2], vidroPosition, staticRotation);
						player.lastTrash = "";
					}
					if(player.lastTrash == "papel"){
						SpawnTrash(lixeiras[3], papelPosition, staticRotation);
						player.lastTrash = "";
					}
					
				}
				timeGame += Time.deltaTime;

				timeText.text = string.Format ("Tempo: {0:F2}", timeGame);
			}
			break;

			case stateMachine.SWITCHCLOTHES :
			{
				
				player.SwitchClothes(player.nextParticules,player.nextMaterial);

			}
			break;

			case stateMachine.LOSE :
			{
				player.playerAnimator.SetBool("dead", true);
				time += Time.deltaTime;
				if(time > 2f) Application.LoadLevel (3);
			}
			break;

			case stateMachine.WIN :
			{
				PlayerPrefs.SetFloat ("time", timeGame);
				Application.LoadLevel (5);
			}
			break;

		}

	}

	public stateMachine GetStateMachine () {
		return currentState;
	}

	void SpawnTrash (GameObject trash, Vector3 position, Quaternion rotation) {
		Instantiate(trash, position, rotation);
	}

	/*private void FollowPlayer () {
		float newPositionZ = 0f; 
		float newPositionX = 0f;
		if(Input.acceleration.y > 0f || Input.acceleration.y < 0f){
			newPositionZ = Mathf.SmoothDamp(transform.position.z, player.transform.position.z, ref currentVelocity, smoothTime);
		}
		if(Input.acceleration.x > 0f || Input.acceleration.y < 0f){
			newPositionX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref currentVelocity, smoothTime);
		}
		transform.position = new Vector3(newPositionX, transform.position.y, newPositionZ);
	} */
}
